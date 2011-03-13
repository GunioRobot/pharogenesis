drawOn: aCanvas 
	"Draw a rectangle with a solid, inset, or raised border.
	Note: the raised border color is generated from the receiver's own color,
	while the inset border color is generated from the color of its owner.
	This behavior is visually more consistent. Thanks to Hans-Martin Mosner."

	| insetColor |
	borderWidth = 0 ifTrue: [  "no border"
		"Note: This is the hook for border styles.
			When converting to the new borders we'll just put 0 into the borderWidth"
		super drawOn: aCanvas.
		^ self].

	borderColor == #raised ifTrue: [
		"Use a hack for now"
		aCanvas fillRectangle: self bounds fillStyle: self fillStyle.
		^ aCanvas frameAndFillRectangle: bounds
			fillColor: Color transparent
			borderWidth: borderWidth
			topLeftColor: (borderWidth = 1 ifTrue: [color twiceLighter]
										ifFalse: [color lighter])
			bottomRightColor: (borderWidth = 1 ifTrue: [color twiceDarker]
										ifFalse: [color darker])].

	borderColor == #inset ifTrue: [
		insetColor _ owner ifNil: [Color black] ifNotNil: [owner colorForInsets].
		aCanvas fillRectangle: self bounds fillStyle: self fillStyle.
		^ aCanvas frameAndFillRectangle: bounds
			fillColor: Color transparent
			borderWidth: borderWidth
			topLeftColor: (borderWidth = 1 ifTrue: [insetColor twiceDarker]
										ifFalse: [insetColor darker])
			bottomRightColor: (borderWidth = 1 ifTrue: [insetColor twiceLighter]
										ifFalse: [insetColor lighter])].

	"solid color border"
	aCanvas fillRectangle: (self bounds insetBy: borderWidth) fillStyle: self fillStyle.
	aCanvas frameAndFillRectangle: bounds
		fillColor: Color transparent
		borderWidth: borderWidth
		borderColor: borderColor.