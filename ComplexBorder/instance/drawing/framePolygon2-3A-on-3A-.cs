framePolygon2: vertices on: aCanvas
	| dir1 dir2 dir3 nrm1 nrm2 nrm3 point1 point2 point3 
	 cross1 cross2 pointA pointB pointC pointD w p1 p2 p3 p4 balloon ends |
	balloon _ aCanvas asBalloonCanvas.
	balloon == aCanvas ifFalse:[balloon deferred: true].
	ends _ Array new: 4.
	w _ width * 0.5.
	pointA _ nil.
	1 to: vertices size do:[:i|
		p1 _ vertices atWrap: i.
		p2 _ vertices atWrap: i+1.
		p3 _ vertices atWrap: i+2.
		p4 _ vertices atWrap: i+3.

		dir1 _ p2 - p1.
		dir2 _ p3 - p2.
		dir3 _ p4 - p3.

		i = 1 ifTrue:[
			"Compute the merge points of p1->p2 with p2->p3"
			cross1 _ dir2 crossProduct: dir1.
			nrm1 _ dir1 normalized. nrm1 _ (nrm1 y * w) @ (0 - nrm1 x * w).
			nrm2 _ dir2 normalized. nrm2 _ (nrm2 y * w) @ (0 - nrm2 x * w).
			cross1 < 0 ifTrue:[nrm1 _ nrm1 negated. nrm2 _ nrm2 negated].
			point1 _ (p1 x + nrm1 x) @ (p1 y + nrm1 y).
			point2 _ (p2 x + nrm2 x) @ (p2 y + nrm2 y).
			pointA _ self intersectFrom: point1 with: dir1 to: point2 with: dir2.
			point1 _ (p1 x - nrm1 x) @ (p1 y - nrm1 y).
			point2 _ (p2 x - nrm2 x) @ (p2 y - nrm2 y).
			pointB _ self intersectFrom: point1 with: dir1 to: point2 with: dir2.
			pointB ifNotNil:[
				(pointB x - p2 x) abs + (pointB y - p2 y) abs > (4*w) ifTrue:[pointA _ pointB _ nil].
			].
		].

		"Compute the merge points of p2->p3 with p3->p4"
		cross2 _ dir3 crossProduct: dir2.
		nrm2 _ dir2 normalized. nrm2 _ (nrm2 y * w) @ (0 - nrm2 x * w).
		nrm3 _ dir3 normalized. nrm3 _ (nrm3 y * w) @ (0 - nrm3 x * w).
		cross2 < 0 ifTrue:[nrm2 _ nrm2 negated. nrm3 _ nrm3 negated].
		point2 _ (p2 x + nrm2 x) @ (p2 y + nrm2 y).
		point3 _ (p3 x + nrm3 x) @ (p3 y + nrm3 y).
		pointC _ self intersectFrom: point2 with: dir2 to: point3 with: dir3.
		point2 _ (p2 x - nrm2 x) @ (p2 y - nrm2 y).
		point3 _ (p3 x - nrm3 x) @ (p3 y - nrm3 y).
		pointD _ self intersectFrom: point2 with: dir2 to: point3 with: dir3.
		pointD ifNotNil:[
			(pointD x - p3 x) abs + (pointD y - p3 y) abs > (4*w) ifTrue:[pointC _ pointD _ nil].
		].
		cross1 * cross2 < 0.0 ifTrue:[
			point1 _ pointA.
			pointA _ pointB.
			pointB _ point1.
			cross1 _ 0.0 - cross1].
		ends at: 1 put: pointA; at: 2 put: pointB; at: 3 put: pointD; at: 4 put: pointC.
		pointA ifNil:["degenerate and slow"
			nrm2 _ dir2 normalized. nrm2 _ (nrm2 y * w) @ (0 - nrm2 x * w).
			cross1 < 0 ifTrue:[nrm2 _ nrm2 negated].
			point2 _ (p2 x + nrm2 x) @ (p2 y + nrm2 y).
			ends at: 1 put: point2].
		pointB ifNil:["degenerate and slow"
			nrm2 _ dir2 normalized. nrm2 _ (nrm2 y * w) @ (0 - nrm2 x * w).
			cross1 < 0 ifTrue:[nrm2 _ nrm2 negated].
			point2 _ (p2 x - nrm2 x) @ (p2 y - nrm2 y).
			ends at: 2 put: point2].
		pointC ifNil:["degenerate and slow"
			nrm2 _ dir2 normalized. nrm2 _ (nrm2 y * w) @ (0 - nrm2 x * w).
			cross2 < 0 ifTrue:[nrm2 _ nrm2 negated].
			point2 _ (p3 x + nrm2 x) @ (p3 y + nrm2 y).
			ends at: 4 put: point2].
		pointD ifNil:["degenerate and slow"
			nrm2 _ dir2 normalized. nrm2 _ (nrm2 y * w) @ (0 - nrm2 x * w).
			cross2 < 0 ifTrue:[nrm2 _ nrm2 negated].
			point2 _ (p3 x - nrm2 x) @ (p3 y - nrm2 y).
			ends at: 3 put: point2].

		self drawPolyPatchFrom: p2 to: p3 on: balloon usingEnds: ends.
		pointA _ pointC.
		pointB _ pointD.
		cross1 _ cross2.
	].
	balloon == aCanvas ifFalse:[balloon flush].