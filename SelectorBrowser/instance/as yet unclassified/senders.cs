senders
	| aSelector |
	(aSelector _ self selectedMessageName) ifNotNil:
		[self systemNavigation browseAllCallsOn: aSelector]