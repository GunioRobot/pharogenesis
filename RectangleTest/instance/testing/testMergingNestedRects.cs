testMergingNestedRects
	| coll merge |
	coll := OrderedCollection new.
	coll add: (Rectangle left: 1 right: 10 top: 1 bottom: 10).
	coll add: (Rectangle left: 4 right: 5 top: 4 bottom: 5).
	merge := Rectangle merging: coll.
	self assert: merge = coll first.