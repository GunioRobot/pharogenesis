reformulateList
	| aMethod |
	"Some uncertainty about how to deal with lost methods here"
	aMethod _ classOfMethod compiledMethodAt: selectorOfMethod ifAbsent: [^ self].
	
	self scanVersionsOf: aMethod class: classOfMethod theNonMetaClass meta: classOfMethod isMeta category: (classOfMethod whichCategoryIncludesSelector: selectorOfMethod) selector: selectorOfMethod.
	self changed: #list. "for benefit of mvc"
	listIndex _ 1.
	self changed: #listIndex.
	self contentsChanged
