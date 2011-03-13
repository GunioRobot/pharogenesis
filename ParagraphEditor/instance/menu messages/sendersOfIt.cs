sendersOfIt
	"Open a senders browser on the selected selector.  1/8/96 sw
	1/18/96 sw: converted to use selectedSelector
	2/29/96 sw: select current line first, if selection was an insertion pt"

	| aSelector |
	self selectLine.
	startBlock = stopBlock ifTrue: [view flash.  ^ self].
	(aSelector _ self selectedSelector) == nil ifTrue: [^ view flash].
	self terminateAndInitializeAround: [Smalltalk browseAllCallsOn: aSelector]