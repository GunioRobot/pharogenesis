initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self setCurrentToolTo: self toolsForPaintBrush.
	formToEdit _ Form extent: 50 @ 40 depth: 8.
	formToEdit fill: formToEdit boundingBox fillColor: Color veryVeryLightGray.
	brushSize _ magnification _ 4.
	
	brushColor _ Color red.
	backgroundColor _ Color white.
	self revert