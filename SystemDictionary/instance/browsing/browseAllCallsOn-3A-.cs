browseAllCallsOn: aLiteral 
	"Create and schedule a message browser on each method that refers to
	aLiteral. For example, Smalltalk browseAllCallsOn: #open:label:."
	(aLiteral isKindOf: LookupKey)
		ifTrue: [self browseMessageList: (self allCallsOn: aLiteral) asSortedCollection
					name: 'Users of ' , aLiteral key
					autoSelect: aLiteral key]
		ifFalse: [self browseMessageList: (self allCallsOn: aLiteral) asSortedCollection
					name: 'Senders of ' , aLiteral
					autoSelect: aLiteral keywords first]