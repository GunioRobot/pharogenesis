buttonLabelInsetFor: aButton
	"Answer the inset to use for a button's label."

	^(aButton showSelectionFeedback xor: aButton getModelState)
		ifTrue: [3@3 corner: 1@1]
		ifFalse: [2]