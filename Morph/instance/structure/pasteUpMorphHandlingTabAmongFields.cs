pasteUpMorphHandlingTabAmongFields
	"Answer the nearest PasteUpMorph in my owner chain that has the tabAmongFields property, or nil if none"

	| aPasteUp |
	aPasteUp _ self owner.
	[aPasteUp notNil] whileTrue:
		[aPasteUp tabAmongFields ifTrue:
			[^ aPasteUp].
		aPasteUp _ aPasteUp owner].
	^ nil