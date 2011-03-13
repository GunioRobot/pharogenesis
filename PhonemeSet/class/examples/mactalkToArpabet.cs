mactalkToArpabet
	"Answer a dictionary with MacTalk phoneme names
	as keys and ARPAbet phonemes as values."

	| answer |
	answer := Dictionary new.
	#(	
		('IY'	'iy')
		('IH'	'ih')
		('EY'	'ey')
		('EH'	'eh')
		('AE'	'ae')
		('AA'	'aa')
		('AO'	'ao')
		('OW'	'ow')
		('UH'	'uh')
		('UW'	'uw')
"		(''	'er')"
		('AX'	'ax')
		('AH'	'ah')
		('AY'	'ay')
		('AW'	'aw')
		('OY'	'oy')
"		(''	'ix')"
		('p'		'p')
		('b'		'b')
		('t'		't')
		('d'		'd')
		('k'		'k')
		('g'		'g')
		('f'		'f')
		('v'		'v')
		('T'		'th')
		('D'		'dh')
		('s'		's')
		('z'		'z')
		('S'		'sh')
		('Z'		'zh')
		('h'		'hh')
		('m'		'm')
		('n'		'n')
		('N'		'ng')
		('l'		'l')
		('w'		'w')
		('y'		'y')
		('r'		'r')
		('C'		'ch')
		('J'		'jh')
		('UX'	'ax')
		('_'		'sil')
		('~'		'sil')) do: [ :each | answer at: each first put: (self arpabet at: each last)].
	^ answer