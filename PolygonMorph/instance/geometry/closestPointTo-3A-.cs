closestPointTo: aPoint 
	| curvePoint closestPoint dist minDist |
	closestPoint := minDist := nil.
	self lineSegmentsDo: 
			[:p1 :p2 | 
			curvePoint := aPoint nearestPointOnLineFrom: p1 to: p2.
			dist := curvePoint dist: aPoint.
			(closestPoint isNil or: [dist < minDist]) 
				ifTrue: 
					[closestPoint := curvePoint.
					minDist := dist]].
	^closestPoint