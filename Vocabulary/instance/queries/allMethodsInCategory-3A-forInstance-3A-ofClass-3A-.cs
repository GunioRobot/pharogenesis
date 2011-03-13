allMethodsInCategory: categoryName forInstance: anObject ofClass: aClass
	"Answer a list of all methods in the etoy interface which are in the given category, on behalf of aClass and possibly anObject.  Note that there is no limitClass at play here."

	| aCategory |
	categoryName ifNil: [^ OrderedCollection new].
	categoryName = self allCategoryName ifTrue:
		[^ methodInterfaces collect: [:anInterface | anInterface selector]].

	aCategory := categories detect: [:cat | cat categoryName == categoryName asSymbol] ifNone: [^ OrderedCollection new].
	^ aCategory elementsInOrder collect: [:anElement | anElement selector] thenSelect:
			[:aSelector | aClass canUnderstand: aSelector]