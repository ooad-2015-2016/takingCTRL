#takingCTRL

Članovi:
1. Alma Hodžić
2. Merisa Hrelja
3. Ahmed Humkić
4. Edo Imamović

###Opis teme:

Auto-otpad "Ibro auto-otpad" je mala kompanija koja se bavi kupoprodajom polovnih autodijelova i servisiranjem automobila.
Kako bi se olakšao rad s korisnicima, te kako bi kompanija pratila savremene načine rada,
vlasnik auto-otpada je odlučio zaposliti grupu programera kako bi mu razvili odgovarajući softver.

Bez ovoga, ako neka osoba želi kupiti ili prodati dio, ili ako želi zakazati termin servisa, morala bi ili doći do radionice u toku radnog vremena, ili u najboljem slučaju kontaktirati radionicu telefonom.

Uz pomoć ovog programa, ovaj proces se automatizira i omogućuje se klijentu da to sve uradi pomoću računara, u bilo koje doba dana.

Sistem predstavlja i svojevrsnu socijalnu mrežu u kojoj **Ibro** igra ulogu posrednika koji omogućava ljudima preprodaju dijelova time što njegova radionica nabavlja dijelove koje korisnici zahtijevaju kroz ovu aplikaciju,
od drugih korisnika iste aplikacije, upotrebom sistema zahtjeva i obavijesti o dijelovima.

###Funkcionalnosti:
*registracija novog korisnika u sistem

*prijava korisnika u sistem

*pretraga i pregledavanje artikala

*mogućnost narudžbe i kupovine artikla

*mogućnost podnošenja zahtjeva za nabavku artikla koji nije na stanju

*mogućnost podnošenja zahtjeva za servisiranje vozila

*mogućnost dodavanja, uređivanja i brisanja artikala (administracija)

*mogućnost odobravanja podnešenih zahtjeva i kreiranja odgovora na iste (radnici)

###Procesi:
1. **registracija korisnika** 
	
	-proces počinje klikom na dugme registracija, korisnik u prikazanu formu unosi ime, prezime, adresu, korisničko ime **(nick)**, e-mail i lozinku.
2. **prijava korisnika**
	
	-korisnik unosi svoj nick i lozinku, sistem verificira podatke i u slučaju uspješnog logina prikazuje korisniku početnu stranicu s odgovarajućim
	rasporedom elemenata, ovisno o ovlastima njegovog korisničkog računa. U slučaju neispravnih korisničkih podataka prikazuje odgovarajuću poruku.
3. **prijava administratora**
	
	-korisnički račun **master** administratora se razlikuje od ostalih, prilikom prijave korisnik u polje predviđeno za prijavu administratora unosi samo
	lozinku, sistem verificira istu, te ukoliko je ispravna prikazuje korisniku administrativnu stranicu, u suprotnom prikazuje obavijest o neuspješnom loginu.
4. **naručivanje artikla**
	
	-kupac pregleda artikle na početnoj stranici, vrši odabir željenog artikla, ukoliko artikal postoji korisnik pokreće proces kupovine. Alternativno,
	ukoliko artikla nema na stanju, korisnik može podnijeti zahtjev za nabavku istog.
5. **zahtjev za nabavku**
	
	-korisnik podnosi zahtjev popunjavajući informacije o modelu i tipu vozila, te samom dijelu koristeći formu predviđenu za to, radnik biva obaviješten o 
	novom zahtjevu, i ako želi odobrava isti, u suprotnom odbija ga uz obrazloženje, ako zahtjev ne bude pregledan u roku od 48 sati sistem ga automatski odbija.
	Odobreni zahtjev se pojavljuje u feedu zahtjeva na stranicama predviđenim za to.
6. **zahtjev za servis**
	
	-korisnik upotrebom forme opisuje tip, model i kvar na vozilu (ukoliko mu je isti poznat), te šalje zahtjev na odobravanje. Radnici nakon pregledanja zahtjeva
	mogu odobriti isti, i rezervisati termin za servis vozila ili ga odbiti uz obrazloženje. Ukoliko zahtjev ne bude pregledan u roku od 48 sati sistem ga automatski odbija.

###Akteri:
#####1. Klijenti
Vanjski korisnici koji kupuju dijelove, nude dijelove koji im ne trebaju, te zakazuju servis.
#####2. Uposlenici
Predstavljaju same radnike prodavnice i servisa, koji na osnovu stvarnog stanja administriraju sistem,
odnosno odobravaju zahtjeve, rezervišu termine i vrše interakciju sa korisnicima.
#####3. Supervizor sistema 
Vlasnik radionice (**Ibro**), ima potpun uvid u sve što se dešava unutar sistema i mogućnost izmjene, dodavanja i brisanja svake moguće stavke.