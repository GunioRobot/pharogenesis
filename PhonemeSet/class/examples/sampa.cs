sampa
	"Answer the sampa phoneme set."
	| answer mapping |
	mapping _ self sampaToArpabet.
	answer _ self new.
	mapping keysDo: [ :each | answer add: ((self arpabet at: (mapping at: each)) copy name: each)].
	^ answer