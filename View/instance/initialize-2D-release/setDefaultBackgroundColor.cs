setDefaultBackgroundColor
	"Obtain the background color from the receiver's model, unless the #uniformWindowColors preference is set to true, in which case obtain it from generic Object; and install it as the receiver's background color.  5/1/96 sw"

	| colorToUse |
	colorToUse _ Preferences uniformWindowColors
		ifTrue:
			[Object new defaultBackgroundColor]
		ifFalse:
			[model defaultBackgroundColor].
	self backgroundColor: colorToUse