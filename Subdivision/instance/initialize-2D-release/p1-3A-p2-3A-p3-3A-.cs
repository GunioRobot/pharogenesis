p1: pt1 p2: pt2 p3: pt3
	| ea eb ec |
	point1 _ pt1.
	point2 _ pt2.
	point3 _ pt3.
	stamp _ 0.
	ea := self quadEdgeClass new.
	(ea first) origin: pt1; destination: pt2.
	eb := self quadEdgeClass new.
	self splice: ea first symmetric with: eb first.
	(eb first) origin: pt2; destination: pt3.
	ec := self quadEdgeClass new.
	self splice: eb first symmetric with: ec first.
	(ec first) origin: pt3; destination: pt1.
	self splice: ec first symmetric with: ea first.
	startingEdge := ea.
