testPositionOfSubCollection
	
	self assert: ((self streamOn: 'xyz') positionOfSubCollection: 'q' ) = 0.
	self assert: ((self streamOn: 'xyz')  positionOfSubCollection: 'x' ) = 1.

	self assert: ((self streamOn: 'xyz') positionOfSubCollection: 'y' ) = 2.
	self assert: ((self streamOn: 'xyz') positionOfSubCollection: 'z' ) = 3.