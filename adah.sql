PGDMP  4    0                |            postgres    16.3    16.3 6    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    5    postgres    DATABASE     |   CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE postgres;
                postgres    false            �           0    0    DATABASE postgres    COMMENT     N   COMMENT ON DATABASE postgres IS 'default administrative connection database';
                   postgres    false    4843                        3079    16384 	   adminpack 	   EXTENSION     A   CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;
    DROP EXTENSION adminpack;
                   false            �           0    0    EXTENSION adminpack    COMMENT     M   COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';
                        false    2            �            1259    16696 	   contracts    TABLE     �   CREATE TABLE public.contracts (
    contract_id integer NOT NULL,
    base_id integer NOT NULL,
    gas_station_id integer NOT NULL
);
    DROP TABLE public.contracts;
       public         heap    postgres    false            �            1259    16695    contracts_contract_id_seq    SEQUENCE     �   CREATE SEQUENCE public.contracts_contract_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public.contracts_contract_id_seq;
       public          postgres    false    227            �           0    0    contracts_contract_id_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public.contracts_contract_id_seq OWNED BY public.contracts.contract_id;
          public          postgres    false    226            �            1259    16610    fuel_at_stations    TABLE     �   CREATE TABLE public.fuel_at_stations (
    id integer NOT NULL,
    gas_station_id integer NOT NULL,
    fuel_type character varying(10) NOT NULL,
    available_quantity integer,
    price_per_liter double precision
);
 $   DROP TABLE public.fuel_at_stations;
       public         heap    postgres    false            �            1259    16609    fuel_at_stations_id_seq    SEQUENCE     �   CREATE SEQUENCE public.fuel_at_stations_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.fuel_at_stations_id_seq;
       public          postgres    false    219            �           0    0    fuel_at_stations_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.fuel_at_stations_id_seq OWNED BY public.fuel_at_stations.id;
          public          postgres    false    218            �            1259    16603    gas_stations    TABLE     �   CREATE TABLE public.gas_stations (
    gas_station_id integer NOT NULL,
    name character varying(100) NOT NULL,
    address character varying(255) NOT NULL,
    status character varying(10) NOT NULL
);
     DROP TABLE public.gas_stations;
       public         heap    postgres    false            �            1259    16602    gas_stations_gas_station_id_seq    SEQUENCE     �   CREATE SEQUENCE public.gas_stations_gas_station_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public.gas_stations_gas_station_id_seq;
       public          postgres    false    217            �           0    0    gas_stations_gas_station_id_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public.gas_stations_gas_station_id_seq OWNED BY public.gas_stations.gas_station_id;
          public          postgres    false    216            �            1259    16629 	   operators    TABLE     �   CREATE TABLE public.operators (
    operator_id integer NOT NULL,
    name character varying(50) NOT NULL,
    password character varying(50) NOT NULL,
    base_id integer
);
    DROP TABLE public.operators;
       public         heap    postgres    false            �            1259    16628    operators_operator_id_seq    SEQUENCE     �   CREATE SEQUENCE public.operators_operator_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public.operators_operator_id_seq;
       public          postgres    false    223            �           0    0    operators_operator_id_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public.operators_operator_id_seq OWNED BY public.operators.operator_id;
          public          postgres    false    222            �            1259    16622    vehicle_bases    TABLE     �   CREATE TABLE public.vehicle_bases (
    base_id integer NOT NULL,
    name character varying(100) NOT NULL,
    address character varying(255) NOT NULL
);
 !   DROP TABLE public.vehicle_bases;
       public         heap    postgres    false            �            1259    16621    vehicle_bases_base_id_seq    SEQUENCE     �   CREATE SEQUENCE public.vehicle_bases_base_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public.vehicle_bases_base_id_seq;
       public          postgres    false    221            �           0    0    vehicle_bases_base_id_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public.vehicle_bases_base_id_seq OWNED BY public.vehicle_bases.base_id;
          public          postgres    false    220            �            1259    16660    vehicles    TABLE     �   CREATE TABLE public.vehicles (
    vehicle_id integer NOT NULL,
    model character varying(50) NOT NULL,
    type character varying(20) NOT NULL,
    fuel_type character varying(10) NOT NULL,
    current_fuel_level integer,
    vehiclebase_id integer
);
    DROP TABLE public.vehicles;
       public         heap    postgres    false            �            1259    16659    vehicles_vehicle_id_seq    SEQUENCE     �   CREATE SEQUENCE public.vehicles_vehicle_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.vehicles_vehicle_id_seq;
       public          postgres    false    225            �           0    0    vehicles_vehicle_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.vehicles_vehicle_id_seq OWNED BY public.vehicles.vehicle_id;
          public          postgres    false    224            9           2604    16699    contracts contract_id    DEFAULT     ~   ALTER TABLE ONLY public.contracts ALTER COLUMN contract_id SET DEFAULT nextval('public.contracts_contract_id_seq'::regclass);
 D   ALTER TABLE public.contracts ALTER COLUMN contract_id DROP DEFAULT;
       public          postgres    false    226    227    227            5           2604    16613    fuel_at_stations id    DEFAULT     z   ALTER TABLE ONLY public.fuel_at_stations ALTER COLUMN id SET DEFAULT nextval('public.fuel_at_stations_id_seq'::regclass);
 B   ALTER TABLE public.fuel_at_stations ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    219    218    219            4           2604    16606    gas_stations gas_station_id    DEFAULT     �   ALTER TABLE ONLY public.gas_stations ALTER COLUMN gas_station_id SET DEFAULT nextval('public.gas_stations_gas_station_id_seq'::regclass);
 J   ALTER TABLE public.gas_stations ALTER COLUMN gas_station_id DROP DEFAULT;
       public          postgres    false    217    216    217            7           2604    16632    operators operator_id    DEFAULT     ~   ALTER TABLE ONLY public.operators ALTER COLUMN operator_id SET DEFAULT nextval('public.operators_operator_id_seq'::regclass);
 D   ALTER TABLE public.operators ALTER COLUMN operator_id DROP DEFAULT;
       public          postgres    false    222    223    223            6           2604    16625    vehicle_bases base_id    DEFAULT     ~   ALTER TABLE ONLY public.vehicle_bases ALTER COLUMN base_id SET DEFAULT nextval('public.vehicle_bases_base_id_seq'::regclass);
 D   ALTER TABLE public.vehicle_bases ALTER COLUMN base_id DROP DEFAULT;
       public          postgres    false    220    221    221            8           2604    16663    vehicles vehicle_id    DEFAULT     z   ALTER TABLE ONLY public.vehicles ALTER COLUMN vehicle_id SET DEFAULT nextval('public.vehicles_vehicle_id_seq'::regclass);
 B   ALTER TABLE public.vehicles ALTER COLUMN vehicle_id DROP DEFAULT;
       public          postgres    false    225    224    225            �          0    16696 	   contracts 
   TABLE DATA           I   COPY public.contracts (contract_id, base_id, gas_station_id) FROM stdin;
    public          postgres    false    227   g?       �          0    16610    fuel_at_stations 
   TABLE DATA           n   COPY public.fuel_at_stations (id, gas_station_id, fuel_type, available_quantity, price_per_liter) FROM stdin;
    public          postgres    false    219   �?       �          0    16603    gas_stations 
   TABLE DATA           M   COPY public.gas_stations (gas_station_id, name, address, status) FROM stdin;
    public          postgres    false    217   �?       �          0    16629 	   operators 
   TABLE DATA           I   COPY public.operators (operator_id, name, password, base_id) FROM stdin;
    public          postgres    false    223   T@       �          0    16622    vehicle_bases 
   TABLE DATA           ?   COPY public.vehicle_bases (base_id, name, address) FROM stdin;
    public          postgres    false    221   �@       �          0    16660    vehicles 
   TABLE DATA           j   COPY public.vehicles (vehicle_id, model, type, fuel_type, current_fuel_level, vehiclebase_id) FROM stdin;
    public          postgres    false    225   �@       �           0    0    contracts_contract_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.contracts_contract_id_seq', 3, true);
          public          postgres    false    226            �           0    0    fuel_at_stations_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.fuel_at_stations_id_seq', 5, true);
          public          postgres    false    218            �           0    0    gas_stations_gas_station_id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public.gas_stations_gas_station_id_seq', 3, true);
          public          postgres    false    216            �           0    0    operators_operator_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.operators_operator_id_seq', 2, true);
          public          postgres    false    222            �           0    0    vehicle_bases_base_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.vehicle_bases_base_id_seq', 2, true);
          public          postgres    false    220            �           0    0    vehicles_vehicle_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.vehicles_vehicle_id_seq', 4, true);
          public          postgres    false    224            E           2606    16703    contracts contracts_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.contracts
    ADD CONSTRAINT contracts_pkey PRIMARY KEY (contract_id);
 B   ALTER TABLE ONLY public.contracts DROP CONSTRAINT contracts_pkey;
       public            postgres    false    227            =           2606    16615 &   fuel_at_stations fuel_at_stations_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public.fuel_at_stations
    ADD CONSTRAINT fuel_at_stations_pkey PRIMARY KEY (id);
 P   ALTER TABLE ONLY public.fuel_at_stations DROP CONSTRAINT fuel_at_stations_pkey;
       public            postgres    false    219            ;           2606    16608    gas_stations gas_stations_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.gas_stations
    ADD CONSTRAINT gas_stations_pkey PRIMARY KEY (gas_station_id);
 H   ALTER TABLE ONLY public.gas_stations DROP CONSTRAINT gas_stations_pkey;
       public            postgres    false    217            A           2606    16634    operators operators_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.operators
    ADD CONSTRAINT operators_pkey PRIMARY KEY (operator_id);
 B   ALTER TABLE ONLY public.operators DROP CONSTRAINT operators_pkey;
       public            postgres    false    223            ?           2606    16627     vehicle_bases vehicle_bases_pkey 
   CONSTRAINT     c   ALTER TABLE ONLY public.vehicle_bases
    ADD CONSTRAINT vehicle_bases_pkey PRIMARY KEY (base_id);
 J   ALTER TABLE ONLY public.vehicle_bases DROP CONSTRAINT vehicle_bases_pkey;
       public            postgres    false    221            C           2606    16665    vehicles vehicles_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.vehicles
    ADD CONSTRAINT vehicles_pkey PRIMARY KEY (vehicle_id);
 @   ALTER TABLE ONLY public.vehicles DROP CONSTRAINT vehicles_pkey;
       public            postgres    false    225            I           2606    16704     contracts contracts_base_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.contracts
    ADD CONSTRAINT contracts_base_id_fkey FOREIGN KEY (base_id) REFERENCES public.vehicle_bases(base_id);
 J   ALTER TABLE ONLY public.contracts DROP CONSTRAINT contracts_base_id_fkey;
       public          postgres    false    227    4671    221            J           2606    16709 '   contracts contracts_gas_station_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.contracts
    ADD CONSTRAINT contracts_gas_station_id_fkey FOREIGN KEY (gas_station_id) REFERENCES public.gas_stations(gas_station_id);
 Q   ALTER TABLE ONLY public.contracts DROP CONSTRAINT contracts_gas_station_id_fkey;
       public          postgres    false    4667    227    217            F           2606    16616 5   fuel_at_stations fuel_at_stations_gas_station_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.fuel_at_stations
    ADD CONSTRAINT fuel_at_stations_gas_station_id_fkey FOREIGN KEY (gas_station_id) REFERENCES public.gas_stations(gas_station_id);
 _   ALTER TABLE ONLY public.fuel_at_stations DROP CONSTRAINT fuel_at_stations_gas_station_id_fkey;
       public          postgres    false    4667    219    217            G           2606    16635     operators operators_base_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.operators
    ADD CONSTRAINT operators_base_id_fkey FOREIGN KEY (base_id) REFERENCES public.vehicle_bases(base_id);
 J   ALTER TABLE ONLY public.operators DROP CONSTRAINT operators_base_id_fkey;
       public          postgres    false    221    223    4671            H           2606    16672 "   vehicles vehicles_vehicle_bases_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.vehicles
    ADD CONSTRAINT vehicles_vehicle_bases_fk FOREIGN KEY (vehiclebase_id) REFERENCES public.vehicle_bases(base_id);
 L   ALTER TABLE ONLY public.vehicles DROP CONSTRAINT vehicles_vehicle_bases_fk;
       public          postgres    false    221    225    4671            �      x�3�4�4�2�F\ƜF��\1z\\\ !��      �   C   x�3�4�t�4�4500�4�2sM9�!\cN#���)�k�d���p�A UXp��F\1z\\\ +?e      �   ]   x�3�tO,V.I,���S0�4��Tp����(8g�T*8r���q��3�440T��KE(t�(4FQh�id`�����P�̙��_������� K>$V      �   &   x�3������442�4�2��J�K�4 N#�=... p\      �   >   x�3�tJ,NU0�442V�M��S.�Qp�,�Tp�2�Hq���%rR�R��N\1z\\\ '$v      �   _   x�-ʽ@0���O�	�?��jG,�vhZ4���|��xj�:�����k����z��w-�x�	�*��+5'�eA4z;^���'kID=��     