backgroundColor
	Display depth <= 2 ifTrue: [^ Color white].
	insideColor ifNotNil: [^ Color colorFrom: insideColor].
	^ superView == nil
		ifFalse: [superView backgroundColor]
		ifTrue:	[Color white]