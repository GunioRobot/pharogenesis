testMergingTrivial
	| coll merge |
	coll := OrderedCollection new.
	coll add: (Rectangle left: 1 right: 1 top: 1 bottom: 1).

	merge := Rectangle merging: coll.
	self assert: merge = coll first.
