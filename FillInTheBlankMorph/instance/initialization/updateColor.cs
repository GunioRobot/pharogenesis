updateColor
	"update the recevier's fillStyle"
	| textPaneBorderColor |
	self
		updateColor: self
		color: self color
		intensity: 1.
	textPane isNil
		ifTrue: [^ self].
	textPaneBorderColor := self borderColor == #raised
				ifTrue: [#inset]
				ifFalse: [self borderColor].
	textPane borderColor: textPaneBorderColor