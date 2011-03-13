noteAddedSelector: aSelector meta: isMeta
	aSelector == #wordingForOperator: ifTrue:
		[Vocabulary changeMadeToViewerAdditions].
	super noteAddedSelector: aSelector meta: isMeta