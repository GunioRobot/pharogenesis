fillRect: rect offset: aPoint
	"The offset is really just for stupid InfiniteForms."
	| fc |
	fillPattern class == InfiniteForm ifTrue:[
		fc _ halftoneForm.
		self fillColor: nil.
		fillPattern displayOnPort: ((self clippedBy: rect) colorMap: nil) at: aPoint.
		halftoneForm _ fc.
		^self].

	destX _ rect left.
	destY _ rect top.
	sourceX _ 0.
	sourceY _ 0.
	width _ rect width.
	height _ rect height.
	self copyBits.