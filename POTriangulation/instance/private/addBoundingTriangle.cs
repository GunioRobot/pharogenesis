addBoundingTriangle
	| radius p1 p2 p3 center |
	radius _ 0.
	center _ 0 @ 0.
	self points do: [:point | center _ center + point].
	center _ center / self points size.
	self points do: [:point | radius _ ((point x - center x) abs max: (point y - center y) abs)
					max: radius].
	radius _ 3 * radius.
	p1 _ radius @ 0 + center.
	p2 _ 0 @ radius + center.
	p3 _ radius negated @ radius negated + center.
	toptriangle _ self triangle: p1 to: p2 to: p3