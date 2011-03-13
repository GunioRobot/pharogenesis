testCopyAfterEmpty
	| result |
	result := self empty copyAfter: self collectionWithoutEqualsElements first.
	self assert: result isEmpty.
	