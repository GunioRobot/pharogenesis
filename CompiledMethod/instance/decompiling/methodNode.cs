methodNode
	"Return the parse tree that represents self"

	| source |
	^ (source := self getSourceFromFile)
		ifNil: [self decompile]
		ifNotNil: [self parserClass new 
					parse: source 
					class: (self methodClass ifNil: [self sourceClass])]