methodNodeFormattedDecompileClass: aClass selector: selector  decorate: decorated
	"Return the parse tree that represents self, using pretty-printed source text if possible."
	| source sClass node |
	source := self getSourceFromFile.
	sClass _ aClass ifNil: [self sourceClass].
	source ifNil: [ ^self decompileClass: sClass selector: selector].
	source _ sClass compilerClass new
						format: source
						in: sClass
						notifying: nil
						decorated: decorated.
	node _ sClass parserClass new
				parse: source
				class: sClass.
	node sourceText: source.
	^node