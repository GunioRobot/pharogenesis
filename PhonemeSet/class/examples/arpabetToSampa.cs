arpabetToSampa
	"Answer a dictionary with ARPAbet phonemes
	as keys and SAMPA phoneme names as values."

	| answer |
	answer _ Dictionary new.
	self sampaToArpabet associationsDo: [ :each | answer at: each value put: each key].
	^ answer