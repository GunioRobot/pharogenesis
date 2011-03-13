initialize
	"
	PhonemeSet initialize
	"
	arpabet := self new name: 'ARPAbet'; description: 'This is the ARPAbet phonetic alphabet.'.
	#("Name"	"Example"	"Features"
		('iy'	'heed'		#(continuant vowel front))
		('ih'	'hid'		#(continuant vowel front))
		('ey'	'hayed'		#(continuant vowel front))
		('eh'	'head'		#(continuant vowel front))
		('ae'	'had'		#(continuant vowel front))
		('aa'	'hod'		#(continuant vowel back))
		('ao'	'hawed'		#(continuant vowel back))
		('ow'	'hoed'		#(continuant vowel back))
		('uh'	'hood'		#(continuant vowel back))
		('uw'	'who''d'		#(continuant vowel back))
		('er'	'heard'		#(continuant vowel mid))
		('ax'	'ago'		#(continuant vowel mid))
		('ah'	'mud'		#(continuant vowel mid))
		('ay'	'hide'		#(diphthong))
		('aw'	'how''d'		#(diphthong))
		('oy'	'boy'		#(diphthong))
		('ix'		'roses'		#())
		('p'		'pea'		#(consonant stop unvoiced))
		('b'		'bat'		#(consonant stop voiced))
		('t'		'tea'		#(consonant stop unvoiced))
		('d'		'deep'		#(consonant stop voiced))
		('k'		'kick'		#(consonant stop unvoiced))
		('g'		'go'			#(consonant stop voiced))
		('f'		'five'		#(continuant consonant fricative unvoiced))
		('v'		'vice'		#(continuant consonant fricative voiced))
		('th'	'thing'		#(continuant consonant fricative unvoiced))
		('dh'	'then'		#(continuant consonant fricative voiced))
		('s'		'so'			#(continuant consonant fricative unvoiced))
		('z'		'zebra'		#(continuant consonant fricative voiced))
		('sh'	'show'		#(continuant consonant fricative unvoiced))
		('zh'	'measure'	#(continuant consonant fricative voiced))
		('hh'	'help'		#(continuant consonant whisper))
		('m'		'mom'		#(continuant consonant nasal))
		('n'		'noon'		#(continuant consonant nasal))
		('ng'	'sing'		#(continuant consonant nasal))		"old name: nx"
		('l'		'love'		#(semivowel liquid))
		('el'		'cattle')
		('em'	'some')
		('en'	'son')
		('dx'	'batter')
		('q'		'[glottal stop]')
		('w'		'want'		#(continuant semivowel glide))
		('y'		'yard'		#(continuant semivowel glide))
		('r'		'race'		#(continuant semivowel liquid))
		('ch'	'church'	#(continuant consonant affricate))
		('jh'	'just'		#(continuant consonant affricate))
		('wh'	'when'		#(semivowel liquid))
	"not found in the original:"
		('sil'	'[silence]'	#(silence))
		('ll'		'')	"dark l"
		('ai'	''			#(vowel))	"what is this?"
		('ia'	''			#(vowel))
		('ea'	''			#(vowel))
		('ua'	''			#(vowel))
		('aor'	'')
		('rx'	''			#())
	) do: [ :each |
		arpabet add: (each size > 2
						ifTrue: [Phoneme name: each first example: each second features: each last]
						ifFalse: [Phoneme name: each first example: each last])].
	arpabet specials at: #silence put: (arpabet at: 'sil')