noteCompilationOf: aSelector meta: isMeta
	aSelector == #wordingForOperator: ifTrue:
		[Vocabulary changeMadeToViewerAdditions].
	super noteCompilationOf: aSelector meta: isMeta