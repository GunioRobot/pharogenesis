browseAllCallsOn: aSymbol 
	"Create and schedule a Message Set browser for all the methods that call 
	on aSymbol."
	| key label |
	(aSymbol isKindOf: LookupKey)
			ifTrue: [label _ 'Users of ' , (key _ aSymbol key)]
			ifFalse: [label _ 'Senders of ' , (key _ aSymbol)].
	^ Smalltalk browseMessageList: (self allCallsOn: aSymbol) asSortedCollection
		name: label autoSelect: key

	"Number browseAllCallsOn: #/."