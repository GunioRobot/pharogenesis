implementorsOfIt
	"Open an implementors browser on the selected selector"

	| aSelector |
	self lineSelectAndEmptyCheck: [^ self].
	(aSelector _ self selectedSelector) == nil ifTrue: [^ view flash].
	self terminateAndInitializeAround: [ self systemNavigation browseAllImplementorsOf: aSelector]