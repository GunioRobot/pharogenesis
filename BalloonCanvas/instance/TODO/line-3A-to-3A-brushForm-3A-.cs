line: point1 to: point2 brushForm: brush
	"Who's gonna use this?"
	| pt1 pt2 |
	self flush. "Sorry, but necessary..."
	transform 
		ifNil:[pt1 _ point1. pt2 _ point2]
		ifNotNil:[pt1 _ transform localPointToGlobal: point1.
				pt2 _ transform localPointToGlobal: point2].
	^super line: pt1 to: pt2 brushForm: brush