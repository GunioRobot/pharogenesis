senders
	| aSelector |
	(aSelector _ self selectedMessageName) ifNotNil:
		[Smalltalk browseAllCallsOn: aSelector]