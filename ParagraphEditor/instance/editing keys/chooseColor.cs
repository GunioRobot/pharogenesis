chooseColor
	"Make a new Text Color Attribute, let the user pick a color, and return the attribute.  This is the non-Morphic version."

	^ TextColor color: (Color fromUser)