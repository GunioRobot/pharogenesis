testAtPut
	self assert: (method properties at: #zork put: 'hello') = 'hello'.
	self assert: (method properties at: #zork) = 'hello'.