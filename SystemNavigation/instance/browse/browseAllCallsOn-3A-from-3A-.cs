browseAllCallsOn: aSymbol from: aClass
	"Create and schedule a Message Set browser for all the methods that call 
	on aSymbol."

	"self new browseAllCallsOn: #/. from: Number"

	| key label |
	label := (aSymbol isKindOf: LookupKey)
			ifTrue: ['Users of ' , (key := aSymbol key)]
			ifFalse: ['Senders of ' , (key := aSymbol)].
	^ self 
		browseMessageList: (self  allCallsOn: aSymbol from: aClass)
		name: label
		autoSelect: key

	