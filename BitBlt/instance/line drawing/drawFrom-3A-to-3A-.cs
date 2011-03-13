drawFrom: startPoint to: stopPoint 
	"Draw a line whose end points are startPoint and stopPoint.
	The line is formed by repeatedly calling copyBits at every
	point along the line."
	| offset point1 point2 |
	"Always draw down, or at least left-to-right"
	((startPoint y = stopPoint y and: [startPoint x < stopPoint x])
		or: [startPoint y < stopPoint y])
		ifTrue: [point1 _ startPoint. point2 _ stopPoint]
		ifFalse: [point1 _ stopPoint. point2 _ startPoint].
	sourceForm == nil ifTrue:
		[destX _ (point1 x - (width//2)) rounded.
		destY _ (point1 y - (height//2)) rounded]
		ifFalse:
		[width _ sourceForm width.
		height _ sourceForm height.
		offset _ sourceForm offset.
		destX _ (point1 x + offset x) rounded.
		destY _ (point1 y + offset y) rounded].
	self drawLoopX: (point2 x - point1 x) rounded 
				  Y: (point2 y - point1 y) rounded