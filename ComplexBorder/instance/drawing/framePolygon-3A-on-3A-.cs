framePolygon: vertices on: aCanvas
	| dir1 dir2 dir3 nrm1 nrm2 nrm3 point1 point2 point3 
	 cross1 cross2 pointA pointB pointC pointD w p1 p2 p3 p4 balloon ends pointE pointF |
	balloon _ aCanvas asBalloonCanvas.
	balloon == aCanvas ifFalse:[balloon deferred: true].
	ends _ Array new: 6.
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

		(i = 1 | true) ifTrue:[
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
			pointB _ point1 + dir1 + point2 * 0.5.
			pointB _ p2 + ((pointB - p2) normalized * w).
			pointC _ point2.
		].

		"Compute the merge points of p2->p3 with p3->p4"
		cross2 _ dir3 crossProduct: dir2.
		nrm2 _ dir2 normalized. nrm2 _ (nrm2 y * w) @ (0 - nrm2 x * w).
		nrm3 _ dir3 normalized. nrm3 _ (nrm3 y * w) @ (0 - nrm3 x * w).
		cross2 < 0 ifTrue:[nrm2 _ nrm2 negated. nrm3 _ nrm3 negated].
		point2 _ (p2 x + nrm2 x) @ (p2 y + nrm2 y).
		point3 _ (p3 x + nrm3 x) @ (p3 y + nrm3 y).
		pointD _ self intersectFrom: point2 with: dir2 to: point3 with: dir3.
		point2 _ (p2 x - nrm2 x) @ (p2 y - nrm2 y).
		point3 _ (p3 x - nrm3 x) @ (p3 y - nrm3 y).
		pointF _ point2 + dir2.
		pointE _ pointF + point3 * 0.5.
		pointE _ p3 + ((pointE - p3) normalized * w).
		cross1 * cross2 < 0.0 ifTrue:[
			ends
				at: 1 put: pointA;
				at: 2 put: pointB;
				at: 3 put: pointC;
				at: 4 put: pointD;
				at: 5 put: pointE;
				at: 6 put: pointF.
		] ifFalse:[
			ends 
				at: 1 put: pointA; 
				at: 2 put: pointB;
				at: 3 put: pointC; 
				at: 4 put: pointF; 
				at: 5 put: pointE;
				at: 6 put: pointD.
		].
		self drawPolyPatchFrom: p2 to: p3 on: balloon usingEnds: ends.
		pointA _ pointD.
		pointB _ pointE.
		pointC _ pointF.
		cross1 _ cross2.
	].
	balloon == aCanvas ifFalse:[balloon flush].