methodNodeDecompileClass: aClass selector: selector
	"Return the parse tree that represents self"

	| source |
	^ (source _ self getSourceFromFile)
		ifNil: [self decompileClass: aClass selector: selector]
		ifNotNil: [self parserClass new parse: source class: (aClass ifNil: [self sourceClass])]