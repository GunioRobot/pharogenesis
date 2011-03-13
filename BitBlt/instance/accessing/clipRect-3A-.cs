clipRect: aRectangle 
	"Set the receiver's clipping area rectangle to be the argument, aRectangle."

	clipX _ aRectangle left.
	clipY _ aRectangle top.
	clipWidth _ aRectangle width.
	clipHeight _ aRectangle height