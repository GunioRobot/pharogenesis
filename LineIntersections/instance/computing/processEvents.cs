processEvents
	| evt |
	intersections _ WriteStream on: (Array new: segments size).
	activeEdges _ OrderedCollection new.
	[events isEmpty] whileFalse:[
		evt _ events removeFirst.
		evt type == #start ifTrue:[self startEdgeEvent: evt].
		evt type == #end ifTrue:[self endEdgeEvent: evt].
		evt type == #cross 
			ifTrue:[self crossEdgeEvent: evt]
			ifFalse:[lastIntersections _ nil].
	].