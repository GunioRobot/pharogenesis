sendersOfIt
	"Open a senders browser on the selected selector"

	| aSelector |
	self lineSelectAndEmptyCheck: [^ self].
	(aSelector := self selectedSelector) == nil ifTrue: [^ self flash].
	self terminateAndInitializeAround: [self systemNavigation browseAllCallsOn: aSelector]