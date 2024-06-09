# Tugas Besar 3 IF2211 Strategi Algoritma

> Pemanfaatan Pattern Matching dalam Membangun Sistem Deteksi Individu Berbasis Biometrik Melalui Citra Sidik Jari

## Table of Contents

-   [General Info](#general-information)
-   [Technologies Used](#technologies-used)
-   [Features](#features)
-   [Setup](#setup)
-   [Usage](#usage)
-   [Project Status](#project-status)
-   [Room for Improvement](#room-for-improvement)
-   [Acknowledgements](#acknowledgements)
-   [Creator](#creator)

## General Information

Pattern matching merupakan teknik penting dalam sistem identifikasi sidik jari. Teknik ini digunakan untuk mencocokkan pola sidik jari yang ditangkap dengan pola sidik jari yang terdaftar di database. Algoritma pattern matching yang umum digunakan adalah Bozorth dan Boyer-Moore. Algoritma ini memungkinkan sistem untuk mengenali sidik jari dengan cepat dan akurat, bahkan jika sidik jari yang ditangkap tidak sempurna.

Pada Tugas Besar 3 ini, kami merancang program untuk menerapkan algoritma KMP (Knuth-Morris-Pratt), BM (Boyer-Moore) yang telah dipelajari di kelas, serta LCS (Longest Common Subsequence) untuk mencari gambar sidik jari yang paling cocok dengan gambar sidik jari yang diberikan pengguna. Setelah itu, kami juga memanfaatkan regex untuk mencari biodata dengan nama yang "cocok" dengan nama yang tertera pada sidik jari, karena atribut nama dalam biodata berisi nama dalam bahasa alay. Program kecil ini dibuat menggunakan bahasa C# dan dijalankan dengan GUI, serta menerima input berupa: 1) Gambar sidik jari yang ingin dicocokkan , serta 2) Pilihan algoritma yang ingin digunakan.

### KMP (Knuth-Morris-Pratt)

Algoritma Knuth-Morris-Pratt (biasa disingkat KMP) adalah algoritma pencarian string yang efisien untuk menemukan kemunculan suatu pola (pattern) dalam teks. Algoritma KMP mencari pola dengan urutan kiri ke kanan (seperti layaknya algoritma brute force). Namun, algoritma ini menggeser pola dengan cara yang lebih pintar dari algoritma brute force, yaitu dengan menggeser pola sebanyak mungkin (dengan tetap menjaga validitas hasil) pada tiap langkahnya untuk menghindari perbandingan yang tidak perlu. Berdasarkan algoritma KMP, jumlah pergeseran maksimal yang mungkin dilakukan pada setiap langkah ketika text[i] ≠ pattern[j] adalah panjang prefix terpanjang dari pattern[0 .. j-1] yang juga merupakan suffix dari pattern[1 .. j-1]. '

### BM (Boyer-Moore)

Algoritma Boyer-Moore (biasa disingkat BM) adalah salah satu algoritma pattern matching yang cukup efisien berdasarkan kompleksitas waktunya, yaitu T(m, n) = m(n - m) + m = O(m\*n) dengan n > m, m adalah panjang string yang ingin dicari (pattern) dan n adalah panjang teks tempat pencarian string (text). Algoritma ini diawali dengan pembuatan tabel Last Occurrence Function (LOF), yaitu melakukan mapping untuk seluruh karakter yang terdapat pada pattern dengan nilai terbesar dari posisi karakter tersebut di dalam pattern. Tabel LOF ini nantinya akan digunakan untuk menghitung banyaknya pergeseran pattern agar pergeseran yang dilakukan lebih optimal.

## Technologies Used

-   .NETFramework, version=v4.7.2
-   MySqlConnector, version=v2.3.5
-   MariaDB, version=v11.3.2

## Features

-   Menggunakan algoritma KMP untuk mencari gambar sidik jari yang cocok dengan gambar sidik jari yang diberikan
-   Menggunakan algoritma BM untuk mencari gambar sidik jari yang cocok dengan gambar sidik jari yang diberikan
-   Menggunakan algoritma LCS untuk mencari gambar sidik jari dengan tingkat persentase kecocokan >= 50% dari sidik jari yang diberikan
-   Menggunakan regex untuk mencari entri biodata dengan nama alay yang sesuai dengan nama yang tertera pada sidik jari
-   Melakukan enkripsi dan dekripsi dari data pada tabel biodata di basis data

## Setup

1. Clone repository ini dengan perintah `git clone https://github.com/IrfanSidiq/Tucil3_13522007.git`
2. Jalankan MariaDB dengan perintah `mariadb -u root` atau `mysql -u root`
3. Buat database baru bernama `stima` dengan perintah `create database stima;`
4. Keluar dari MariaDB dengan perintah `quit`
5. Lanjut ke tahap setup database di bawah

### Setup Database

Terdapat 3 contoh database awal yang kami gunakan, yaitu `template.sql`, `normal.sql`, dan `encrypted.sql`. Ketiga contoh database tersebut mengikuti skema database yang telah disediakan di spek.

-   `template.sql` berisi database kosong yang belum diisi data.
-   `normal.sql` berisi database yang telah diisi dengan beberapa data awal (isi datanya belum di-enkripsi).
-   `encrypted.sql` berisi database yang isi datanya telah di-enkripsi.

Berikut contoh cara untuk menggunakan database tersebut:

1. Pindah ke folder src/database
2. Lakukan dump sql ke database stima dengan perintah `mysql -u root -p -h localhost stima < [nama_database].sql`, dengan `[nama_database].sql` dapat berupa salah satu dari ketiga database diatas, maupun database lain yang sudah Anda persiapkan.

### Cara Menggunakan Fitur Dekripsi Database

Program secara default menerima data yang belum di-enkripsi. Untuk mengaktifkan fitur dekripsi pada database yang telah di-enkripsi, perlu dilakukan sedikit perubahan pada program:

1. Pindah ke folder `src/Tubes3GUI`
2. Buka file `Class2.cs`
3. Pada kelas `ConnectDB`, ubah nilai boolean `decryptDatabase` dari `false` menjadi `true`
4. Lakukan dump sql yang telah di-enkripsi (misalnya `encrypted.sql`) sesuai dengan perintah diatas

## Usage

1. Pindah ke folder `src`
2. Buka file `Tubes3GUI.sln` menggunakan Microsoft Visual Studio
3. Tekan tombol Start pada sisi atas Microsoft Visual Studio untuk memulai program

## Project Status

Project is: _complete_

## Room for Improvement

Pengembangan kedepannya dapat dilakukan dengan menambahkan fitur berikut:

-   Mempercantik tampilan GUI
-   Mengembangkan cara handling regex yang lebih fleksibel, tak hanya terbatas untuk regex optional dan or

## Acknowledgements

Ucapan terima kasih diberikan kepada:

-   Pak Rinaldi Munir selaku dosen mata kuliah IF2211 yang telah mengajarkan materi UCS, Greedy Best-First Search, dan A\*
-   Tim Asisten yang telah membimbing untuk membuat tugas besar 3 ini

## Creator

| NIM      | Nama                        |
| -------- | --------------------------- |
| 13522007 | Irfan Sidiq Permana         |
| 13522041 | Ahmad Hasan Albana          |
| 13522078 | Venantius Sean Ardi Nugroho |
