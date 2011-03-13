methodNodeFormatted
	"Answer a method node made from pretty-printed (and colorized, if decorate is true) 
	 source text."

	| class source node  |
	
	source := self getSourceFromFile.
	class := self methodClass ifNil: [self sourceClass].
	source ifNil: [^self decompile].
	source := class prettyPrinterClass 
				format: source
				in: class
				notifying: nil.
	node := class parserClass new parse: source class: class.
	node sourceText: source.
	^node