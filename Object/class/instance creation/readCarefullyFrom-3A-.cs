readCarefullyFrom: textOrString
	"Create an object based on the contents of textOrString.  Return an error instead of putting up a SyntaxError window."

	| object ok |
	ok _ (textOrString isKindOf: Stream) or: [textOrString isKindOf: String].
	(ok or: [textOrString isKindOf: Text]) ifFalse: [^ self error: 'expected String or Text'].
	object _ Compiler evaluate: textOrString for: nil 
				notifying: #error: "signal we want errors" logged: false.
	(object isKindOf: self) ifFalse: [self error: self name, ' expected'].
	^object