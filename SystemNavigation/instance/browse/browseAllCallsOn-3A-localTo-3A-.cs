browseAllCallsOn: aLiteral localTo: aClass
	"Create and schedule a message browser on each method in or below the given class that refers to
	aLiteral. For example, Smalltalk browseAllCallsOn: #open:label:."

	aClass ifNil: [ ^self inform: 'no selected class' ].
	(aLiteral isKindOf: LookupKey)
		ifTrue: [self browseMessageList: (aClass allLocalCallsOn: aLiteral) asSortedCollection
					name: 'Users of ' , aLiteral key, ' local to ', aClass name
					autoSelect: aLiteral key]
		ifFalse: [self browseMessageList: (aClass allLocalCallsOn: aLiteral) asSortedCollection
					name: 'Senders of ' , aLiteral, ' local to ', aClass name
					autoSelect: aLiteral keywords first]