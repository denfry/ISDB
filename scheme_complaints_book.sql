
CREATE SEQUENCE complaints_book.models_seq;

CREATE TABLE complaints_book.models (
                model_code INTEGER NOT NULL DEFAULT nextval('complaints_book.models_seq'),
                model_name VARCHAR(100) NOT NULL,
                model_type VARCHAR(50) NOT NULL,
                CONSTRAINT model_code PRIMARY KEY (model_code)
);


ALTER SEQUENCE complaints_book.models_seq OWNED BY complaints_book.models.model_code;

CREATE SEQUENCE complaints_book.complaints_complaint_id_seq;

CREATE TABLE complaints_book.complaints (
                complaint_id INTEGER NOT NULL DEFAULT nextval('complaints_book.complaints_complaint_id_seq'),
                complaint_year INTEGER DEFAULT 2025 NOT NULL,
                complaint_month INTEGER DEFAULT 1 NOT NULL,
                model_code INTEGER NOT NULL,
                price NUMERIC(10,2) DEFAULT 0.00 NOT NULL,
                complaint_count INTEGER DEFAULT 0 NOT NULL,
                units_sold INTEGER DEFAULT 0 NOT NULL,
                CONSTRAINT complaint_id PRIMARY KEY (complaint_id)
);


ALTER SEQUENCE complaints_book.complaints_complaint_id_seq OWNED BY complaints_book.complaints.complaint_id;

ALTER TABLE complaints_book.complaints ADD CONSTRAINT models_complaints_fk
FOREIGN KEY (model_code)
REFERENCES complaints_book.models (model_code)
ON DELETE RESTRICT
ON UPDATE RESTRICT
NOT DEFERRABLE;
