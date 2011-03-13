drawOn: aCanvas
	| borderColorToUse |
	borderColorToUse _ status == #field
		ifTrue:
			[Color blue muchLighter]
		ifFalse:
			[Color red lighter].
	aCanvas frameAndFillRectangle: bounds
		fillColor: Color blue veryMuchLighter
		borderWidth: 1
		borderColor: borderColorToUse.

	super drawOn: aCanvas.