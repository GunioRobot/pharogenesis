clobberContentsOfTabNamed: aName
	"For the purposes of trimming down save-file size, offer to substitute an empty place-holder of the same name."

	| aBook |
	(self objectAtTab: aName) ifNil: [^ self].
	aBook _ BookMorph new.
	aBook insertPageShowingString: 'nulled out' usingFont: nil.
	^ aBook