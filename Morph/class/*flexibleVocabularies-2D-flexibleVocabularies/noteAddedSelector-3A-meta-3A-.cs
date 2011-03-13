noteAddedSelector: aSelector meta: isMeta
	"Any change to an additionsToViewer... method can invalidate existing etoy vocabularies.
	The #respondsTo: test is to allow loading the FlexibleVocabularies change set without having to worry about method ordering."
	(isMeta
			and: [(aSelector beginsWith: 'additionsToViewer')
					and: [self respondsTo: #hasAdditionsToViewerCategories]])
		ifTrue: [Vocabulary changeMadeToViewerAdditions].
	super noteCompilationOf: aSelector meta: isMeta