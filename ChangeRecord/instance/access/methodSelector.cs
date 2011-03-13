methodSelector
	^type == #method ifTrue:
		[(Smalltalk at: class ifAbsent: [Object]) parserClass new parseSelector: self string]