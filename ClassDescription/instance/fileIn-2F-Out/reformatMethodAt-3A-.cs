reformatMethodAt: selector 
	| newCodeString method | 
	newCodeString _ (self compilerClass new)
		format: (self sourceCodeAt: selector)
		in: self
		notifying: nil
		decorated: false.
	method _ self compiledMethodAt: selector.
	method
		putSource: newCodeString
		fromParseNode: nil
		class: self
		category: (self organization categoryOfElement: selector)
		inFile: 2 priorMethod: method