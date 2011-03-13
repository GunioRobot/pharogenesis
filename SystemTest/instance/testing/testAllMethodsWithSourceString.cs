testAllMethodsWithSourceString
	"self debug: #testAllMethodsWithSourceString"

	| result classes |
	self t6 compile: 'foo self das2d3oia'.
	
	result := SystemNavigation default
		allMethodsWithSourceString: '2d3oi' matchCase: false.
	self assert: result size = 2.
	
	classes := result collect: [:each | each actualClass].
	self assert: (classes includesAllOf: {self t6. self class}).
	
	self assert: (SystemNavigation default
		allMethodsWithSourceString: '2d3asdas' , 'ascascoi' matchCase: false) isEmpty.