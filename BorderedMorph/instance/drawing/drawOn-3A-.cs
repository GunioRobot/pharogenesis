drawOn: aCanvas 
	"Draw a rectangle with a solid, inset, or raised border.
	Note: the raised border color is generated from the receiver's own color,
	while the inset border color is generated from the color of its owner.
	This behavior is visually more consistent. Thanks to Hans-Martin Mosner."

	| insetColor |
	borderWidth = 0 ifTrue: [  "no border"
		aCanvas fillRectangle: bounds color: color.
		^ self].

	borderColor == #raised ifTrue: [
		^ aCanvas frameAndFillRectangle: bounds
			fillColor: color
			borderWidth: borderWidth
			topLeftColor: color lighter
			bottomRightColor: color darker].

	borderColor == #inset ifTrue: [
		insetColor _ owner colorForInsets.
		^ aCanvas frameAndFillRectangle: bounds
			fillColor: color
			borderWidth: borderWidth
			topLeftColor: insetColor darker
			bottomRightColor: insetColor lighter].

	"solid color border"
	aCanvas frameAndFillRectangle: bounds
		fillColor: color
		borderWidth: borderWidth
		borderColor: borderColor.