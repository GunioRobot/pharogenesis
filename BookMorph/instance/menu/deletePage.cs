deletePage

	| oldPage |
	oldPage _ currentPage.
	self nextPage.
	pages remove: oldPage.
	oldPage delete.
	currentPage = oldPage ifTrue: [self nextPage].
	pages isEmpty ifTrue: [self insertPage].
