foregroundColor
	borderColor ifNotNil: [^ Color colorFrom: borderColor].
	^ superView == nil
		ifFalse: [superView foregroundColor]
		ifTrue:	[Color black]