implementors
	| aSelector |
	(aSelector _ self selectedMessageName) ifNotNil:
		[Smalltalk browseAllImplementorsOf: aSelector]