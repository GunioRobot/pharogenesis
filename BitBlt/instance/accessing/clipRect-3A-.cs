clipRect: aRectangle 
	"Set the receiver's clipping area rectangle to be the argument, aRectangle."

	clipX _ aRectangle left truncated.
	clipY _ aRectangle top truncated.
	clipWidth _ aRectangle right truncated - clipX.
	clipHeight _ aRectangle bottom truncated - clipY.