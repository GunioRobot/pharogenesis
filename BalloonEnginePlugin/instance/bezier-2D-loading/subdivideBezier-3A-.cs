subdivideBezier: index
	"Subdivide the given bezier curve if necessary"
	| startX startY endX endY deltaX deltaY |
	self inline: false.
	startY _ self bzStartY: index.
	endY _ self bzEndY: index.

	"If the receiver is horizontal, don't do anything"
	(endY = startY) ifTrue:[^index].

	"TODO: If the curve can be represented as a line, then do so"

	"If the height of the curve exceeds 256 pixels, subdivide 
	(forward differencing is numerically not very stable)"
	deltaY _ endY - startY.
	deltaY < 0 ifTrue:[deltaY _ 0 - deltaY].
	(deltaY > 255) ifTrue:[
		self incrementStat: GWBezierHeightSubdivisions by: 1.
		^self computeBezierSplitAtHalf: index].

	"Check if the incremental values could possibly overflow the scaled integer range"
	startX _ self bzStartX: index.
	endX _ self bzEndX: index.
	deltaX _ endX - startX.
	deltaX < 0 ifTrue:[deltaX _ 0 - deltaX].
	deltaY * 32 < deltaX ifTrue:[
		self incrementStat: GWBezierOverflowSubdivisions by: 1.
		^self computeBezierSplitAtHalf: index].
	^index
