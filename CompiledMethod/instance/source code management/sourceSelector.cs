sourceSelector
	"Answer my selector extracted from my source.  If no source answer nil"

	| sourceString |
	sourceString _ self getSourceFromFile ifNil: [^ nil].
	^ Compiler parserClass new parseSelector: sourceString