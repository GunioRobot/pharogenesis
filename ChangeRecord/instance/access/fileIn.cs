fileIn
	| methodClass |
	Cursor read showWhile:
		[(methodClass _ self methodClass) notNil ifTrue:
			[methodClass compile: self text classified: category withStamp: stamp notifying: nil].
		(type == #doIt) ifTrue:
			[Compiler evaluate: self string].
		(type == #classComment) ifTrue:
			[(Smalltalk at: class asSymbol) comment: self text]]