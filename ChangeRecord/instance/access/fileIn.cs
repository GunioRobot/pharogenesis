fileIn
	| methodClass |
	Cursor read showWhile:
		[(methodClass _ self methodClass) notNil ifTrue:
			[methodClass compile: self string classified: category].
		type = #doIt ifTrue:
			[Compiler evaluate: self string]]