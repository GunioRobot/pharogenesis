testAtIfAbsentPut
	self assert: (method properties at: #zork ifAbsentPut: [ 'hello' ]) = 'hello'.
	self assert: (method properties at: #zork ifAbsentPut: [ 'hi' ]) = 'hello'.