optionalButtonPairs
	"Actually, return triples.  In mvc (until someone deals with this) only the custom debugger-specific buttons are shown, but in morphic, the standard code-tool buttons are provided in addition to the custom buttons"

	^ Smalltalk isMorphic
		ifFalse:
			[self customButtonSpecs]
		ifTrue:
			[super optionalButtonPairs]