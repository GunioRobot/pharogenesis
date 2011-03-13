default
	| phonemes inherents lowers |
	phonemes := PhonemeSet arpabet.
	inherents := Dictionary new.
	lowers := Dictionary new.
	#(
	('ae'	230.0	80.0)
	('aa'	240.0	100.0)
	('ax'	120.0	60.0)
	('er'	180.0	80.0)
	('ay'	250.0	150.0)
	('aw'	240.0	100.0)
	('b'		85.0		60.0)
	('ch'	70.0		50.0)
	('d'		75.0		50.0)
	('dh'	50.0		30.0)
	('eh'	150.0	70.0)
	('ea'	270.0	130.0)
	('ey'	180.0	100.0)
	('f'		100.0	80.0)
	('g'		80.0		60.0)
	('hh'	80.0		20.0)
	('ih'	135.0	40.0)
	('ia'	230.0	100.0)
	('iy'	155.0	55.0)
	('jh'	70.0		50.0)
	('k'		80.0		60.0)
	('l'		80.0		40.0)
	('m'		70.0		60.0)
	('n'		60.0		50.0)
	('ng'	95.0		60.0)
"	('oh'	240.0	130.0)"
	('oy'	280.0	150.0)
	('ao'	240.0	130.0)
	('ow'	220.0	80.0)
	('p'		90.0		50.0)
	('r'		80.0		30.0)
	('s'		105.0	60.0)
	('sh'	105.0	80.0)
	('t'		75.0		50.0)
	('th'	90.0		60.0)
	('uh'	210.0	70.0)
	('ua'	230.0	110.0)
	('ah'	160.0	60.0)
	('uw'	230.0	150.0)
	('v'		60.0		40.0)
	('w'		80.0		60.0)
	('y'		80.0		40.0)
	('z'		75.0		40.0)
	('zh'	70.0		40.0)
	('sil'	100.0	100.0)) do: [ :each |
		inherents at: (phonemes at: each first) put: each second / 1000.0.
		lowers at: (phonemes at: each first) put: each last / 1000.0].
	^ self inherents: inherents lowers: lowers