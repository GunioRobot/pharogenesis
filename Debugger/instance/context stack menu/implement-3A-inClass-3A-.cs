implement: aMessage inClass: aClass
	
	| category |
	category := self askForCategoryIn: aClass default: 'as yet unclassified'.
	aClass compile: aMessage createStubMethod classified: category.
	self setContentsToForceRefetch.
	self selectedContext privRefreshWith: (aClass lookupSelector: aMessage selector).
	aMessage arguments doWithIndex: [:arg :i |
		self selectedContext at: i put: arg.
	].
	self resetContext: self selectedContext.
	self debug.
