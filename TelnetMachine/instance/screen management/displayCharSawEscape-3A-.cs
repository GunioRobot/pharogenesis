displayCharSawEscape: c
	"display a character from the mode #sawEscape"

	c = $[ ifTrue: [
		commandParams _ OrderedCollection with: 0.
		displayMode _ #gatheringParameters.
		^self ].
	
	displayMode _ #normal.
	^self displayChar: c