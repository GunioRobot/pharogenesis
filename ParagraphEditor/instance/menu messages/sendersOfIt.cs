sendersOfIt
	"Open a senders browser on the selected selector"

	| aSelector |
	self lineSelectAndEmptyCheck: [^ self].
	(aSelector _ self selectedSelector) == nil ifTrue: [^ view flash].
	self terminateAndInitializeAround: [self systemNavigation browseAllCallsOn: aSelector]