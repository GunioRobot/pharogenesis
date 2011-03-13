recompile: selector from: oldClass
	"Compile the method associated with selector in the receiver's method dictionary."

	| method trailer methodNode |
	method _ self compiledMethodAt: selector.
	trailer _ (method size - 2 to: method size) collect: [:i | method at: i].
	methodNode _ self compilerClass new
				compile: (oldClass sourceCodeAt: selector)
				in: self
				notifying: nil
				ifFail: [].
	methodNode == nil  "Try again after proceed from SyntaxError"
		ifTrue: [^self recompile: selector from: oldClass].
	selector == methodNode selector ifFalse: [self error: 'selector changed!'].
	self addSelector: selector withMethod: (methodNode generate: trailer).
