testCopyUpToLastEmpty
	| result |
	result := self empty copyUpToLast: self collectionWithoutEqualsElements first.
	self assert: result isEmpty.