implementors
	| aSelector |
	(aSelector _ self selectedMessageName) ifNotNil:
		[self systemNavigation browseAllImplementorsOf: aSelector]