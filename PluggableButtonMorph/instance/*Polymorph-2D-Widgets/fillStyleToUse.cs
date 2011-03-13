fillStyleToUse
	"Return the fillStyle to use for the receiver."
	
	|fs state mo|
	fs := super fillStyle.
	Preferences gradientButtonLook ifFalse:[^fs].
	state := self getModelState.
	mo := self containsMousePoint.
	fs := (self enabled ifNil: [true])
		ifTrue: [showSelectionFeedback
			ifTrue: [state
				ifTrue: [self selectedPressedFillStyle]
				ifFalse: [self pressedFillStyle]]
			ifFalse: [mo
				ifTrue: [state
					ifTrue: [self selectedMouseOverFillStyle]
					ifFalse: [self mouseOverFillStyle]]
				ifFalse: [state
					ifTrue: [self selectedFillStyle]
					ifFalse: [self normalFillStyle]]]]
		ifFalse: [state
			ifTrue: [self selectedDisabledFillStyle]
			ifFalse: [self disabledFillStyle]].
	^fs