destRect: aRectangle 
	"Set the receiver's destination form top left coordinates to be the origin of 
	the argument, aRectangle, and set the width and height of the receiver's 
	destination form to be the width and height of aRectangle."

	destX _ aRectangle left.
	destY _ aRectangle top.
	width _ aRectangle width.
	height _ aRectangle height