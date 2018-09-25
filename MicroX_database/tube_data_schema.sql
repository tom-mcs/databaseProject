-- tube_data_schema.sql - database schema for collected tube data
-- Copyright (C) 2018 Micro-X Ltd
-- Version: 1.0

-- set role to mx_engineering
SET ROLE mx_engineering;


-- drop tables if they exist
DROP TABLE IF EXISTS tube_data CASCADE;
DROP TABLE IF EXISTS eol_shot CASCADE;
DROP TABLE IF EXISTS fss_data CASCADE;
DROP TABLE IF EXISTS exposure_data CASCADE;
DROP TABLE IF EXISTS errors CASCADE;
DROP TABLE IF EXISTS dose_measurements CASCADE;
DROP TABLE IF EXISTS systems CASCADE;
DROP TABLE IF EXISTS testers CASCADE;
-- linking tables
DROP TABLE IF EXISTS exposure_errors CASCADE;
DROP TABLE IF EXISTS tube_system CASCADE;
DROP TABLE IF EXISTS tube_tester CASCADE;

DROP TYPE getter;
DROP TYPE iec;
DROP TYPE status;

-- Create enum type for getter firing
CREATE TYPE getter AS ENUM ('no', 'normal', 'low-power');
-- Create enum type for IEC focal spot sizes
CREATE TYPE iec AS ENUM ('0.9', '1.0', '1.1', '1.2', '1.3', '1.4',
 '1.5', '1.6', '1.7', '1.8', '1.9');
-- Create enum type for exposure result
CREATE TYPE status AS ENUM (
       'OK',           -- Exposure complete, no errors
       'MISFIRE',      -- Exposure terminated by error, dose produced
       'NONFIRE',      -- Exposure terminated by error, no dose produced
       'POSTERR',      -- Exposure terminated by error, sufficient dose produced
       'TERMINATED',   -- Exposure terminated by time limit
       'DVDT');        -- Exposure was part of dv/dt ramping

-- table to hold tube data
CREATE TABLE tube_data(
  tube_nr CHAR(8) PRIMARY KEY,  -- serial number of tube
  cathode_nr CHAR(8) UNIQUE,    -- serial number of cathode assembly
  gc_height_avg REAL,           -- avg height grid-cathode
  gc_height_min REAL,           -- min height grid-cathode
  gc_height_max REAL,           -- max height grid-cathode
  gc_height_stdev REAL,         -- stdev height grid-cathode
  R_25 REAL,                    -- Resistance at 25mA in kOhm
  R_60 REAL,                    -- Resistance at 60mA in kOhm
  eol_R_grid INTEGER,           -- Resistance from eol report in Ohm
  eol_Vz INTEGER,               -- Reference voltage (V)
  eol_focus_corr INTEGER,       -- Focus correction factor
  eol_Ia REAL,                  -- Anode current used for Transmission
  eol_Ic REAL,                  -- Cathode current used for Transmission
  eol_T REAL,                   -- Transmission rate
  eol_V_grid_peak INTEGER,      --
  eol_Ia_55kV_09mm REAL,        --
  eol_Ifs_09mm REAL,            --
  eol_Ifs_19mm REAL,            --
  eq_alum_half REAL,            --
  eq_alum_Ic_init INTEGER,      --
  eq_alum_Ic_limit INTEGER,     --
  station_id CHAR(8),           --
  slit_diaphragm CHAR(8),       --
  carestream_HPX CHAR(8),       --
  focal_spot_stand CHAR(8),     --
  film1 CHAR(8),                --
  film2 CHAR(8),                --
  raysafe_base_unit CHAR(8),    --
  raysafe_sensor CHAR(8),       --
  getters_fired getter,         -- When were getters fired
  disc_thickness REAL           -- Thickness of Tungsten disc in mm
);

-- table to hold EOL shot data from Xinray, we may not have this
-- for all tubes.
CREATE TABLE eol_shot(
  nr SERIAL PRIMARY KEY,        -- auto-incrementing number
  tube_nr CHAR(8) REFERENCES tube_data(tube_nr), -- foreign key
  kV INTEGER,                   -- shot kVp
  mAs REAL,                     -- mAs
  T REAL,                       -- transmission rate for shot
  Ia REAL,                      -- anode current for shot in mA
  Ic REAL,                      -- cathode current for shot in mA
  Vf INTEGER,                   -- focus voltage
  If REAL                       -- focus current
);

-- table to hold FSS data from Xinray and potentially EOL
CREATE TABLE fss_data(
  nr SERIAL PRIMARY KEY,       -- auto-incrementing number
  tube_nr CHAR(8) REFERENCES tube_data(tube_nr), -- foreign key
  kV INTEGER,                  -- kV
  fss iec,                     -- IEC Target
  Vf INTEGER,                  -- Focus voltage applied
  fsl REAL,                    -- FSS Length in mm
  fsw REAL                     -- FSS Width in mm
);

-- table to hold exposure data
CREATE TABLE exposure_data(
  exp_id BIGSERIAL PRIMARY KEY, -- shot id, auto gen
  tube_nr CHAR(8) NOT NULL REFERENCES tube_data(tube_nr), --foreign key
  exp_ts TIMESTAMP NOT NULL,    -- date/time of exposure
  exp_status status NOT NULL,   -- exposure status
  shot_count INTEGER NOT NULL,  -- value of shot counter for the shot
  pre_kV INTEGER,               -- kV setpoint
  pre_mAs REAL,                 -- mAs setpoint
  pre_Ia INTEGER,               -- anode current setpoint
  pre_ms INTEGER,               -- exposure time setpoint
  pre_Ic INTEGER,               -- cathode current setpoint
  pre_Vgc INTEGER,              -- estimated Vgc
  pre_Vf INTEGER,               -- focus voltage setpoint
  pre_fss iec,                  -- required FSS
  post_kV INTEGER NOT NULL,     -- actual kV
  post_mAs REAL NOT NULL,       -- actual mAs
  post_Ia REAL,                 -- actual anode current (mA)
  post_ms INTEGER,              -- actual exposure time in ms
  post_Ic REAL,                 -- actual cathode current (mA)
  post_Vgc INTEGER,             -- actual Vgc
  post_Vf_xrs INTEGER,          -- actual focus voltage as seen by supply
  post_Vf_tube INTEGER,         -- actual focus voltage as seen by tube
  post_If_pre REAL,             -- actual focus current prior to emitter activation
  post_If_after REAL,           -- actual focus current after emitter activation
  post_Tshot REAL,              -- actual transmission rate for shot
  post_Tavg REAL,               -- actual average transmission rate
  post_Rg INTEGER,              -- actual estimate for tube resistance
  post_Vz INTEGER,              -- actual estimate for tube reference voltage
  post_dap REAL,                -- actual DAP reading for the shot
  CONSTRAINT u_shot UNIQUE (tube_nr,exp_ts,shot_count)
);

-- table to hold all error definitions
CREATE TABLE errors(
  errno CHAR(4) PRIMARY KEY,    -- error code per DOC042
  error_name VARCHAR,           -- error name per DOC042
  description VARCHAR           -- error description per DOC042
);

-- table to hold shot errors
CREATE TABLE exposure_errors(
  exp_id BIGSERIAL REFERENCES exposure_data(exp_id),
  errno CHAR(4) REFERENCES errors(errno),
  PRIMARY KEY (exp_id,errno)
);

-- table to hold dose measurements
CREATE TABLE dose_measurements(
  nr SERIAL PRIMARY KEY,        --
  tube_nr CHAR(8) REFERENCES tube_data(tube_nr),  --
  kV INTEGER,                   --
  Ic_init INTEGER,              --
  Ic_limit INTEGER,             --
  kVp_a REAL,                   --
  mAs REAL,                     --
  ms REAL,                      --
  dose REAL                     --
);

--table to hold system information (specific carts, rigs etc)
CREATE TABLE systems(
  sys_nr CHAR(8) PRIMARY KEY
);

--table to store details of tube use in system
CREATE TABLE tube_system(
  nr SERIAL PRIMARY KEY ,                           --
  sys_nr CHAR(8) REFERENCES systems(sys_nr),        --
  tube_nr CHAR(8) REFERENCES tube_data(tube_nr),    --
  start TIMESTAMP,                                  --
  finish TIMESTAMP                                  --
);

--table to store XinRay tester information
CREATE TABLE testers(
  nr SERIAL PRIMARY KEY,      --
  first_name VARCHAR,         --
  last_name VARCHAR           --
);

CREATE TABLE tube_tester(
  tester_nr SERIAL REFERENCES testers(nr),        --
  tube_nr CHAR(8) REFERENCES tube_data(tube_nr),  --
  PRIMARY KEY (tester_nr, tube_nr)
);

-- enter error data
INSERT INTO errors (errno,error_name,description) VALUES
  ('E1','High Anode mA in exposure','Anode mA is 20% higher than expected.'),
  ('E2','Low Anode mA in exposure','Anode mA is 20% lower than expected.'),
  ('E3','mA present in standby phase','Anode mA detected in standby phase.'),
  ('E6','High Anode kV','Anode kV is 10% higher than expected.'),
  ('E7','Low Anode kV','Anode kV is 10% lower than expected.'),
  ('E8','Anode kV present during standby','Anode kV detected in standby phase.'),
  ('E11','Grid kV present during standby','Grid kV detected in standby phase.'),
  ('E12','High Grid mA','Grid mA is 5% higher than expected.'),
  ('E13','Low Grid mA','Grid mA is 5% lower than expected.'),
  ('E14','High Focus kV','Focus kV is 20% higher than expected.'),
  ('E15','Low Focus kV','Focus kV is 20% lower than expected.'),
  ('E16','Focus kV present during standby','Focus kV detected in standby phase.'),
  ('E19','DAC reference error','Digital to Analog convertor voltage reference is not within 1% tolerance.'),
  ('E20','High +24VDC','+24VDC internal voltage supply exceeds +15% tolerance.'),
  ('E21','Low +24VDC','+24VDC internal voltage supply below -15% tolerance.'),
  ('E23','High Ambient temperature','Ambient temperature exceeds maximum limit of 50 degree Celsius.'),
  ('E24','High +12VDC','+12VDC internal voltage supply exceeds maximum tolerance of 15%.'),
  ('E25','Low +12VDC','+12VDC internal voltage supply below minimum tolerance of -15%.'),
  ('E26','High -12VDC','-12VDC internal voltage supply exceeds maximum tolerance of 15%.'),
  ('E27','Low -12VDC','-12VDC internal voltage supply below minimum tolerance of -15%.'),
  ('E29','High VDC Input','VDC input from cart to XRS exceeds maximum limit of 80V.'),
  ('E30','Low VDC Input','VDC input from cart to XRS below minimum limit of 50V.'),
  ('E31','Exposure Input Error','Exposure switch input detected active during power-on sequence (i.e. at startup).'),
  ('E32','Prep Input Error','Prep switch input detected active during power-on sequence (i.e. at startup).'),
  ('E33','Anode mA Overcurrent Trip','Anode mA has exceeded absolute maximum hardware limit during exposure.'),
  ('E34','Anode kV Overvoltage Trip','Anode kV exceeded absolute maximum hardware level during exposure.'),
  ('E35','Resonant Current Trip','Resonant current exceeded absolute maximum hardware limit during exposure.'),
  ('E36','Inverter Current Trip','Inverter current exceeded absolute maximum hardware level during exposure.'),
  ('E37','Grid Over Voltage Fault ','Grid kV exceeds absolute maximum hardware trip level.'),
  ('E38','Focus Over Voltage Fault','Focus kV exceeds absolute maximum hardware trip level.'),
  ('E40','Anode Arc Detect','Anode Arc detected.'),
  ('E41','Grid Arc Detect','Grid Arc detected.'),
  ('E42','Focus Arc Detect','Focus Arc detected.'),
  ('E43','Anode-to-Focus Arc Detect','Anode-to-Focus Arc detected'),
  ('E44','Exposure backup time is exceeded.','mAs interrupt signal is still not activated after 450 ms of exposure.'),
  ('E45','DC Bus Charge Error','DC Bus fails to charge.'),
  ('E46','HVM Cable Interlock Error','High Voltage Module feedback cable is not connected.'),
  ('E47','DC Bus Discharge Error','DC Bus discharge circuit failure.'),
  ('E52','Invalid communication message','XRS has detected an invalid communication message.'),
  ('E53','Message not supported','Requested communication message not supported.'),
  ('E55','Corrupted Tube data','Tube data corrupted'),
  ('E57','Manually terminated exposure ','Exposure switch was released before exposure completed'),
  ('E58','Prep switch closed','Prep switch remains closed 30 seconds after exposure'),
  ('E59','Exposure switch closed','Exposure switch remains closed 30 seconds after exposure'),
  ('E60','DC bus low during Prep state','DC bus voltage is lower than 380V in prep state.'),
  ('E64','Corrupted generator statistics data','Generator statistics data corrupted.'),
  ('E65','High +15VDC','+15VDC voltage supply higher than maximum tolerance of +15%'),
  ('E66','Low  +15VDC','+15VDC voltage supply below minimum tolerance of -15%'),
  ('E67','mAs present during standby','mAs detected in standby phase.'),
  ('E68','Grid mA present during standby','Grid mA detected in standby phase.'),
  ('E69','Exposure switch input is active when prep switch is activated','Exposure switch input detected active during prep on.'),
  ('E75','Invalid Application Image','There is no application image on XRS board or the application image is corrupted.'),
  ('E76','Tube Focus Fault','Focus voltage measured on tube side has deviated by +/-10% from Focus supply output.'),
  ('E80','XRS hardware incompatibility based on electronic IDs of Grid / Focus / Control / Cap-Charger.,"EID on one of XRS FRU boards is either not programmed, or programmed incorrectly',' or incompatible with each other."'),
  ('E81','DC Bus voltage is higher than 400V','DC Bus voltage is higher than 400V.'),
  ('E82','mAs Integration circuit times out','Software has not cleared or acknowledged mAs interrupt within 8 ms of its occurrence.'),
  ('E83','Focus Over Current Fault','Focus current exceeds absolute maximum hardware trip level.'),
  ('E84','Grid Over Current Fault','Grid current exceeds absolute maximum hardware trip level.'),
  ('E85','Factory default jumper is set.','Factory default jumper on Control is set.'),
  ('E86','mAs inaccuracy','Exposure finishes successfully but actual mAs is more than +/-(10%+0.2 mAs ) away from the requested mAs.'),
  ('E87','Cable to tube disconnected',' When setpoint > 500V and terminal <50V.'),
  ('E100','Time limit exceeded','Exposure time >10% over expected time'),
  ('E88','Focus terminal voltage out of range',' When setpoint <=500V and out by >=25%.'),
  ('E501','XRS kW limit ','Requested parameter exceeds XRS kW limit.'),
  ('E502','XRS kV limit high','Requested kV exceeds XRS kV maximum limit.'),
  ('E503','XRS kV limit low','Requested kV below XRS kV minimum limit.'),
  ('E504','XRS mAs limit high','Requested mAs exceeds XRS mAs maximum limit.'),
  ('E505','XRS mAs limit low','Requested mAs below XRS mAs minimum limit.'),
  ('E510','XRS mA limit high','Requested kV or mAs causes XRS mA to exceed maximum limit.'),
  ('E511','XRS mA limit low','Requested kV or mAs causes XRS mA to exceed maximum limit.'),
  ('E512','XRS ms limit high','Requested kV or mAs causes XRS mA to exceed maximum limit.'),
  ('E513','XRS ms limit low','Requested kV or mAs causes XRS mA to exceed maximum limit.'),
  ('E514','XRS Grid KV limit high','Requested kV or mAs causes XRS grid kV to exceed maximum limit.'),
  ('E515','XRS Grid KV limit low','Requested kV or mAs causes XRS grid kV below minimum limit.'),
  ('E516','XRS Focus KV limit high','Requested kV or mAs causes XRS focus kV to exceed maximum limit.'),
  ('E517','XRS Focus KV limit low','Requested kV or mAs causes XRS focus kV below minimum limit.'),
  ('E520','kV/mAs limit reached.','The user has requested a kV/mAs combination that is not permitted by the system'),
  ('E521','Grid mA Determination Failed','XRS cannot figure out the grid mA.'),
  ('E523','Focus Voltage Determination Failed','XRS cannot figure out the focus voltage.'),
  ('E525','mAs value is not on mAs station','The requested mAs value is not on mAs station.'),
  ('E537','Command comes in a wrong generator state','Command comes in when generator is in a state where this command shall be processed.'),
  ('E538','VDC input from cart to XRS is lower than 62V but still higher than 50V','VDC input from cart to XRS is lower than 62V but still higher than 50V.');

