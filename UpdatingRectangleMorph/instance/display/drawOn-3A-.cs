drawOn: aCanvas 
	"Copied down from BorderedMorph, with the substitution that the color inst var of the receiver here might well be something like #raised or some other symbol, which the frameAndFillRectangle... methods barf on."

	| insetColor colorToFill |
	colorToFill _ (color isKindOf: Color) ifTrue: [color] ifFalse: [Color gray].
	borderWidth = 0 ifTrue: [  "no border"
		aCanvas fillRectangle: bounds color: color.
		^ self].

	borderColor == #raised ifTrue:
		[^ aCanvas frameAndFillRectangle: bounds
			fillColor: colorToFill
			borderWidth: borderWidth
			topLeftColor: colorToFill lighter
			bottomRightColor: colorToFill darker].

	borderColor == #inset ifTrue:
		[insetColor _ owner colorForInsets.
		^ aCanvas frameAndFillRectangle: bounds
			fillColor: colorToFill
			borderWidth: borderWidth
			topLeftColor: insetColor darker
			bottomRightColor: insetColor lighter].

	"solid color border"
	aCanvas frameAndFillRectangle: bounds
		fillColor: colorToFill
		borderWidth: borderWidth
		borderColor: borderColor.