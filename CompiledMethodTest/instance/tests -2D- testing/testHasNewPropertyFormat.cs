testHasNewPropertyFormat
		| method |
		method := (self class)>>#returnTrue.
		self assert: method hasNewPropertyFormat.
