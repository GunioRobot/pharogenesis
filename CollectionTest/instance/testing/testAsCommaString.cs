testAsCommaString
	{OrderedCollection new. Set new.} do:
		[ :coll |
		self assert: coll asCommaString = ''.

		coll add: 1.
		self assert: coll asCommaString = '1'.

		coll add: 2; add: 3.
		self assert: coll asCommaString = '1, 2, 3'].