borderStyleToUse
	"Return the borderStyle to use for the receiver."
	
	|state mo|
	Preferences gradientButtonLook ifFalse:[^super borderStyle].
	state := self getModelState.
	mo := self containsMousePoint.
	^(self enabled ifNil: [true])
		ifTrue: [showSelectionFeedback
			ifTrue: [state
				ifTrue: [self selectedPressedBorderStyle]
				ifFalse: [self pressedBorderStyle]]
			ifFalse: [mo
				ifTrue: [state
					ifTrue: [self selectedMouseOverBorderStyle]
					ifFalse: [self mouseOverBorderStyle]]
				ifFalse: [state
					ifTrue: [self selectedBorderStyle]
					ifFalse: [self normalBorderStyle]]]]
		ifFalse: [state
			ifTrue: [self selectedDisabledBorderStyle]
			ifFalse: [self disabledBorderStyle]]