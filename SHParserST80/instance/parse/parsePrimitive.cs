parsePrimitive
	self scanNext.
	currentTokenFirst isDigit 
		ifTrue: [self scanPast: #integer]
		ifFalse: [
			self failUnless: [currentTokenFirst = $'].
			self parseString.
			currentToken = 'module:' 
				ifTrue: [
					self scanPast: #module.
					self failUnless: [currentTokenFirst = $'].
					self parseString]].
	self failUnless: [currentToken = '>'].
	self scanPast: #primitiveOrExternalCallEnd