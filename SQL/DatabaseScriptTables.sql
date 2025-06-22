/*This script is used to create the necessary tables for the SQL database.
  
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "Dictionary" (
    "ID" UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    "Date" DATE NOT NULL,
    "Handwriting" VARCHAR(100) NOT NULL,
    "Pronunciation" VARCHAR(100) NULL,
    "Meaning" TEXT NULL,
    "Category" INTEGER NULL
)
 */