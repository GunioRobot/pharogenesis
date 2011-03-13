browseReference: ref
	self okToChange ifTrue: [
	self selectCategoryForClass: ref actualClass theNonMetaClass.
	self selectClass: ref actualClass theNonMetaClass .
	ref actualClass isMeta ifTrue: [self indicateClassMessages].
	self changed: #classSelectionChanged.
	self selectMessageCategoryNamed: ref category.
	self selectedMessageName: ref methodSymbol.
	]