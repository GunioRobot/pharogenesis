testMergingDisjointRects
	| coll merge |
	coll := OrderedCollection new.
	coll add: (Rectangle left: -10 right: 0 top: -10 bottom: 0).
	coll add: (Rectangle left: 0 right: 10 top: 0 bottom: 10).
	merge := Rectangle merging: coll.
	self assert: merge = (Rectangle left: -10 right: 10 top: -10 bottom: 10).