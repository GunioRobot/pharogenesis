getSourceFor: selector in: class
	"Retrieve or reconstruct the source code for this method."
	| source flagByte |
	flagByte _ self last.
	flagByte = 0 ifTrue:
		["No source pointer -- decompile without temp names"
		^ (class decompilerClass new decompile: selector in: class method: self)
			decompileString].
	flagByte < 252 ifTrue:
		["Magic sources -- decompile with temp names"
		^ ((class decompilerClass new withTempNames: self tempNames)
				decompile: selector in: class method: self)
			decompileString].

	"Situation normal;  read the sourceCode from the file"
	(source _ self getSourceFromFile) == nil ifFalse: [^ source].

	"Something really wrong -- decompile blind (no temps)"
	^ (class decompilerClass new decompile: selector in: class method: self)
			decompileString