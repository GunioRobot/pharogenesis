test0FixtureDictionaryIncludesIdentity
	| |
	self	shouldnt: [ self nonEmptyWithCopyNonIdentical  ]raise: Error.
	self deny: self nonEmptyWithCopyNonIdentical  isEmpty.
	
	self nonEmptyWithCopyNonIdentical do: [ :each | self deny: each == each copy ].
	
	