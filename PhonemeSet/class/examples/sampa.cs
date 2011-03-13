sampa
	"Answer the sampa phoneme set."
	| answer mapping |
	mapping := self sampaToArpabet.
	answer := self new.
	mapping keysDo: [ :each | answer add: ((self arpabet at: (mapping at: each)) copy name: each)].
	^ answer