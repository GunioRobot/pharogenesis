drawOn: aCanvas 
	"Draw a rectangle with a solid, inset, or raised border.
	Note: the raised border color *and* the inset border color are generated
	from the receiver's own color, instead of having the inset border color
	generated from the owner's color, as in BorderedMorph."

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
		^ aCanvas frameAndFillRectangle: bounds
			fillColor: color
			borderWidth: borderWidth
			topLeftColor: color darker
			bottomRightColor: color lighter].

	"solid color border"
	aCanvas frameAndFillRectangle: bounds
		fillColor: color
		borderWidth: borderWidth
		borderColor: borderColor.