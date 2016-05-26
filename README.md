﻿#takingCTRL

Članovi:
1. Alma Hodžić
2. Merisa Hrelja
3. Ahmed Humkić
4. Edo Imamović

###Opis teme:

Auto-otpad "Ibro Autodijelovi" je mala kompanija koja se bavi kupoprodajom polovnih autodijelova i servisiranjem automobila.
Kako bi se olakšao rad s korisnicima, te kako bi kompanija pratila savremene načine rada,
vlasnik auto-otpada je odlučio zaposliti grupu programera kako bi mu razvili odgovarajući softver.

Bez ovoga, ako neka osoba želi kupiti ili prodati dio, ili ako želi zakazati termin servisa, morala bi ili doći do radionice u toku radnog vremena, ili u najboljem slučaju kontaktirati radionicu telefonom.

Uz pomoć ovog programa, ovaj proces se automatizira i omogućuje se klijentu da to sve uradi pomoću računara, u bilo koje doba dana.

Sistem predstavlja i svojevrsnu socijalnu mrežu u kojoj **Ibro** igra ulogu posrednika koji omogućava ljudima preprodaju dijelova time što njegova radionica nabavlja dijelove koje korisnici zahtijevaju kroz ovu aplikaciju,
od drugih korisnika iste aplikacije, upotrebom sistema zahtjeva i obavijesti o dijelovima.


###Procesi:
1. **registracija korisnika** 
	
	-proces počinje klikom na dugme registracija. Korisnik u prikazanu formu unosi ime, prezime, adresu, korisničko ime **(nick)**, e-mail i lozinku. Na mail
	se šalje random generisani broj. Korisnik ga naknadno unosi, čime njegov račun postaje upotrebljiv.
2. **prijava korisnika**
	
	-korisnik unosi svoj nick i lozinku, sistem verificira podatke i u slučaju uspješnog logina prikazuje korisniku početnu stranicu s odgovarajućim
	rasporedom elemenata, ovisno o ovlastima njegovog korisničkog računa. U slučaju neispravnih korisničkih podataka prikazuje odgovarajuću poruku.
3. **prijava administratora**
	
	-korisnički račun **master** administratora se razlikuje od ostalih, prilikom prijave korisnik u polje predviđeno za prijavu administratora unosi samo
	lozinku, sistem verificira istu, te ukoliko je ispravna prikazuje korisniku administrativnu stranicu, u suprotnom prikazuje obavijest o neuspješnom loginu.
4. **naručivanje artikla**
	
	-kupac pregleda artikle na početnoj stranici i vrši odabir željenog artikla. Ukoliko artikal postoji, korisnik pokreće proces kupovine. Alternativno,
	ukoliko artikla nema na stanju, korisnik može podnijeti zahtjev za nabavku istog (opisano pod 5). Prilikom narudžbe, korisnik ispunjava neke dodatne podatke
	i ugovara način plaćanja. Za artikal koji se doda, prodavač može dodati sliku dijela, te ako želi, korištenjem eksternog servisa generisati QR kod (trgovcu može
	biti korisno da za svaki dio koji ima u radionici ima i QR kod na kojem brzo čita kompaktno zapisane informacije o dijelu).

5. **nabavka dijela za auto**
	
	-korisnik podnosi zahtjev popunjavajući informacije o modelu i tipu vozila, te samom dijelu koji mu treba koristeći formu predviđenu za to. Radnici bivaju obaviješten o 
	novom zahtjevu, i ako žele odobravaju isti. U suprotnom, odbija ga uz obrazloženje; ako zahtjev ne bude pregledan u roku od 48 sati sistem ga automatski odbija.
	Odobreni zahtjev se pojavljuje u feedu zahtjeva na stranicama predviđenim za to. Sve odobrene zahtjeve mogu vidjeti svi korisnici sistema, te ako posjeduju traženi dio, prodati ga auto-otpadu.


6. **zahtjev za servis**
	
	-korisnik upotrebom forme opisuje tip, model i kvar na vozilu (ukoliko mu je isti poznat), te šalje zahtjev na odobravanje. Radnici nakon pregledanja zahtjeva
	mogu odobriti isti, i rezervisati termin za servis vozila ili ga odbiti uz obrazloženje. Ukoliko zahtjev ne bude pregledan u roku od 48 sati sistem ga automatski odbija.
	

###Funkcionalnosti:
* registracija novog korisnika u sistem
* prijava korisnika u sistem
* pregled svih artikala na stanju
* pretraga artikala
* mogućnost narudžbe i kupovine artikla
* mogućnost podnošenja zahtjeva za nabavku artikla koji nije na stanju
* mogućnost podnošenja zahtjeva za servisiranje vozila
* mogućnost dodavanja, uređivanja i brisanja artikala (administracija)
* mogućnost odobravanja podnešenih zahtjeva i kreiranja odgovora na iste (radnici)
* kreiranje QR pomoću eksternog servisa (ukoliko se bude mogao iskoristiti servis)
* čitanje QR koda pomoću kamere (ukoliko bude dovoljno jednostavno implementirati)
* dodavanje slike dijela koji se prodaje pomoću kamere (-//-)
* plaćanje preko PayPala (-//-)

###Akteri:
#####1. Neregistrovani klijent
Korisnik koji može samo pregledati dijelove koji se prodaju, eventualno registrovati se.
#####2. Registrovani klijent
Korisnik koji može naručiti ili prodati dio ili zakazati servis
#####2. Uposlenici
Predstavljaju same radnike prodavnice i servisa, koji na osnovu stvarnog stanja administriraju sistem,
odnosno odobravaju zahtjeve, rezervišu termine i vrše interakciju sa korisnicima.
#####3. Supervizor sistema 
Vlasnik radionice (**Ibro**), ima potpun uvid u sve što se dešava unutar sistema i mogućnost izmjene, dodavanja i brisanja svake moguće stavke. On je zadužen za registraciju uposlenika.
#####4. Vanjski servisi (planirano generator QR koda, PayPal)
