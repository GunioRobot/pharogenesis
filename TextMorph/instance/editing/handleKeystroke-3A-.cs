handleKeystroke: anEvent
	"System level event handling."
	| pasteUp |
	anEvent wasHandled ifTrue:[^self].
	(self handlesKeyboard: anEvent) ifFalse:[^self].
	anEvent wasHandled: true.
	anEvent keyCharacter = Character tab ifTrue:[
		"Allow passing through text morph inside pasteups"
		pasteUp _ self pasteUpMorph.
		(self wouldAcceptKeyboardFocusUponTab  and:[pasteUp hasProperty: #tabAmongFields])
			ifTrue:[^ pasteUp tabHitWithEvent: anEvent]].
	^self keyStroke: anEvent