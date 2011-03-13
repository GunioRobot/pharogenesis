sendersOfIt
	"Open a senders browser on the selected selector"

	| selector |
	self lineSelectAndEmptyCheck: [^ self].
	(selector _ self selectedSelector) == nil ifTrue: [^ view flash].
	self send: #sendersOfIt: toModelWith: {selector} orDo: [super sendersOfIt]