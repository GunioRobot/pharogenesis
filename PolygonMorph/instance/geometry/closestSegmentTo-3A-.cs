closestSegmentTo: aPoint
	"Answer the starting index of my (big) segment nearest to aPoint"
	| curvePoint closestPoint dist minDist vertexIndex closestVertexIndex |
	vertexIndex _ 0.
	closestVertexIndex _ 0.
	closestPoint _ minDist _ nil.
	self lineSegmentsDo:
		[:p1 :p2 | 
		(p1 = (self vertices at: vertexIndex + 1))
			ifTrue: [ vertexIndex _ vertexIndex + 1 ].
		curvePoint _ aPoint nearestPointOnLineFrom: p1 to: p2.
		dist _ curvePoint dist: aPoint.
		(closestPoint == nil or: [dist < minDist])
			ifTrue: [closestPoint _ curvePoint.
					minDist _ dist.
					closestVertexIndex _ vertexIndex. ]].
	^ closestVertexIndex