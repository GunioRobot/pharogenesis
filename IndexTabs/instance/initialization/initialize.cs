initialize
	"Initialize the receiver.  Make sure it is not open to drag and drop"

	super initialize.
	padding _ 10.
	verticalPadding _ 4.
	basicHeight _ 14.
	basicWidth _ 200.
	color _ Color r: 0.0 g: 0.6 b: 0.6.
	borderWidth _ 0.
	self enableDragNDrop: false