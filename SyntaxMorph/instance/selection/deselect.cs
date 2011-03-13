deselect
	self allMorphsDo:
		[:m | m isSyntaxMorph ifTrue: [m color: Color transparent; borderColor: Color transparent]].

	"Note following is wasteful because we do a deselect before each select, and it is often the same morph."
	self deletePopup