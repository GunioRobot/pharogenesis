codeMessage: receiver selector: selector arguments: arguments
	| symbol node |
	symbol _ selector key.
	(node _ BraceNode new
			matchBraceWithReceiver: receiver
			selector: symbol
			arguments: arguments) ifNotNil: [^ node].
	(node _ self decodeIfNilWithReceiver: receiver
			selector: symbol
			arguments: arguments) ifNotNil: [^ node].
	^ MessageNode new
			receiver: receiver selector: selector
			arguments: arguments
			precedence: symbol precedence