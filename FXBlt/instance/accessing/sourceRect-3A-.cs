sourceRect: aRectangle 
	"Set the receiver's source form top left x and y, width and height to be 
	the top left coordinate and extent of the argument, aRectangle."

	sourceX _ aRectangle left.
	sourceY _ aRectangle top.
	width _ aRectangle width.
	height _ aRectangle height