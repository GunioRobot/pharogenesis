initializeEvents
	"Initialize the events for all given line segments"
	| mySeg pt1 pt2 |
	events _ WriteStream on: (Array new: segments size * 2).
	segments do:[:seg|
		pt1 _ seg start asPoint.
		pt2 _ seg end asPoint.
		(pt1 sortsBefore: pt2) 
			ifTrue:[mySeg _ LineIntersectionSegment from: pt1 to: pt2]
			ifFalse:[mySeg _ LineIntersectionSegment from: pt2 to: pt1].
		mySeg referentEdge: seg.
		events nextPut: (LineIntersectionEvent type: #start position: mySeg start segment: mySeg).
		events nextPut: (LineIntersectionEvent type: #end position: mySeg end segment: mySeg).
	].
	events _ Heap withAll: events contents sortBlock: [:ev1 :ev2| ev1 sortsBefore: ev2].