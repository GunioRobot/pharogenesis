regularize: pointCollection
	"Make the pointList non-intersecting, e.g., insert points at intersections and have the outline include those points"
	| pointList segments last intersections map pts |
	pointList _ pointCollection collect:[:pt| pt asIntegerPoint].
	segments _ WriteStream on: (Array new: pointList size).
	last _ pointList last.
	pointList do:[:next|
		segments nextPut: (LineSegment from: last to: next).
		last _ next.
	].
	segments _ segments contents.
	intersections _ LineIntersections of: segments.
	map _ IdentityDictionary new: segments size.
	intersections do:[:is|
		(map at: is second ifAbsentPut:[WriteStream on: (Array new: 2)]) nextPut: is first.
		(map at: is third ifAbsentPut:[WriteStream on: (Array new: 2)]) nextPut: is first.
	].
	pts _ WriteStream on: (Array new: pointList size).
	segments do:[:seg|
		intersections _ (map at: seg) contents.
		intersections _ intersections sort:
			[:p1 :p2|  (p1 squaredDistanceTo: seg start) <= (p2 squaredDistanceTo: seg start)].
		last _ intersections at: 1.
		pts nextPut: last.
		intersections do:[:next|
			(next = last and:[next = seg end]) ifFalse:[
				pts nextPut: next.
				last _ next]].
	].
	^pts contents