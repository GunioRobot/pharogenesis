closestPointTo: aPoint
	| curvePoint closestPoint dist minDist |
	closestPoint _ minDist _ nil.
	self lineSegmentsDo:
		[:p1 :p2 | 
		curvePoint _ aPoint nearestPointOnLineFrom: p1 to: p2.
		dist _ curvePoint dist: aPoint.
		(closestPoint == nil or: [dist < minDist])
			ifTrue: [closestPoint _ curvePoint.
					minDist _ dist]].
	^ closestPoint