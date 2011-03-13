dectalkToArpabet
	"Answer a dictionary with DECTalk phoneme names
	as keys and ARPAbet phonemes as values."

	| answer |
	answer := Dictionary new.
	self arpabet do: [ :each | answer at: each name put: each].
	#(
		('nx'	'ng')
		('yx'	'jh')
		('lx'		'l')
		('rr'	'r')
		('u'		'uw')
		('hx'	'hh')
		('h'		'hh')
		('_'		'sil')) do: [ :each | answer at: each first put: (self arpabet at: each last)].
	^ answer