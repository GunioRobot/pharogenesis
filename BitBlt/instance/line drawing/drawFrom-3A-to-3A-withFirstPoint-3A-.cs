drawFrom: startPoint to: stopPoint withFirstPoint: drawFirstPoint
	"Draw a line whose end points are startPoint and stopPoint.
	The line is formed by repeatedly calling copyBits at every
	point along the line.  If drawFirstPoint is false, then omit
	the first point so as not to overstrike at line junctions."
	| offset point1 point2 forwards |
	"Always draw down, or at least left-to-right"
	forwards _ (startPoint y = stopPoint y and: [startPoint x < stopPoint x])
				or: [startPoint y < stopPoint y].
	forwards
		ifTrue: [point1 _ startPoint. point2 _ stopPoint]
		ifFalse: [point1 _ stopPoint. point2 _ startPoint].
	sourceForm == nil ifTrue:
		[destX _ point1 x.
		destY _ point1 y]
		ifFalse:
		[width _ sourceForm width.
		height _ sourceForm height.
		offset _ sourceForm offset.
		destX _ (point1 x + offset x) rounded.
		destY _ (point1 y + offset y) rounded].

	"Note that if not forwards, then the first point is the last and vice versa.
	We agree to always paint stopPoint, and to optionally paint startPoint."
	(drawFirstPoint or: [forwards == false  "ie this is stopPoint"])
		ifTrue: [self copyBits].
	self drawLoopX: (point2 x - point1 x) rounded 
				  Y: (point2 y - point1 y) rounded.
	(drawFirstPoint or: [forwards  "ie this is stopPoint"])
		ifTrue: [self copyBits].
