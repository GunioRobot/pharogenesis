testNumArgs
	"This is about http://code.google.com/p/pharo/issues/detail?id=237"
	
	self assert: ('*+-/\~=<>&@%,|' allSatisfy: [:char | (String with: char) numArgs = 1])
		description: 'binary selectors have 1 argument'.
		
	self assert: 'x' numArgs = 0
		description: 'unary selectors have 0 arguments'.
	self assert: 'x0' numArgs = 0
		description: 'unary selectors have 0 arguments'.
	self assert: 'yourself' numArgs = 0
		description: 'unary selectors have 0 arguments'.
		
	self assert: 'x:' numArgs = 1
		description: 'keyword selectors have as many elements as colons characters'.
	self assert: 'x:y:' numArgs = 2
		description: 'keyword selectors have as many elements as colons characters'.
	self assert: 'at:put:' numArgs = 2
		description: 'keyword selectors have as many elements as colons characters'.
		
	self assert: 'at:withoutTrailingColon' numArgs = -1
		description: 'keyword selectors should have a trailing colon character'.
		
	self assert: ':x' numArgs = -1
		description: 'keyword selectors cannot begin with a colon character'.
		
	self assert: 'x::y:' numArgs = -1
		description: 'keyword selectors cannot have two consecutive colon characters'.
	
	self assert: '0x' numArgs = -1
		description: 'selectors cannot begin with a digit'.
	
	"This one is known to fail...
	self assert: 'x:0:' numArgs = -1
		description: 'no keyword selector part can begin with a digit'.
	"
	
	