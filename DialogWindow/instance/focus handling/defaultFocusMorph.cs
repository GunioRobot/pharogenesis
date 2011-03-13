defaultFocusMorph
	"Answer the morph that should have the keyboard
	focus by default when the dialog is opened."
	
	^self defaultButton
		ifNil: [(self respondsTo: #nextMorphWantingFocus)
					ifTrue: [	self nextMorphWantingFocus]]
		ifNotNilDo: [:b | b enabled ifTrue: [b]]