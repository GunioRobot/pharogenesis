testCopyEmptyMethod
	| result |
	result := self collectionWithoutEqualsElements  copyEmpty .
	self assert: result isEmpty .
	self assert: result class= self nonEmpty class.