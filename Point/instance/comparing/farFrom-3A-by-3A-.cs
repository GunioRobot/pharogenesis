farFrom: aPoint by: distance
	| pt delta |
	pt _ (self - aPoint) abs.
	delta _ distance asPoint.
	^ pt x > delta x or: [pt y > delta y]