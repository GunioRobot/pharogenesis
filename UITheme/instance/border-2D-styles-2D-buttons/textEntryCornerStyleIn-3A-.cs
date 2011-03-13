textEntryCornerStyleIn: aThemedMorph
	"Answer the corner style to use for text entry morphs."
	
	^aThemedMorph
		ifNil: [#square]
		ifNotNilDo: [:tm | tm preferredCornerStyle]