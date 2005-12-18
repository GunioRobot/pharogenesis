implement: aMessage inClass: aClass
	
	| category |
	category := self askForCategoryIn: aClass default: 'as yet unclassified'.
	aClass compile: aMessage createStubMethod classified: category.

	self setContentsToForceRefetch.
	self selectedContext privRefreshWith: (aClass lookupSelector: aMessage selector).
	self selectedContext temps: aMessage arguments.
	self resetContext: self selectedContext.
	self debug.
