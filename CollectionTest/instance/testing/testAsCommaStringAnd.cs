testAsCommaStringAnd
	{OrderedCollection new. Set new.} do:
		[ :coll |
		self assert: coll asCommaStringAnd = ''.

		coll add: 1.
		self assert: coll asCommaStringAnd = '1'.

		coll add: 2; add: 3.
		self assert: coll asCommaStringAnd = '1, 2 and 3'].