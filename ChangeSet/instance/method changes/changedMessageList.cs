changedMessageList
	"Used by a message set browser to access the list view information."

	| messageList |
	messageList _ SortedCollection new.
	changeRecords associationsDo: 
		[:clAssoc | 
		clAssoc value methodChangeTypes associationsDo: 
			[:mAssoc | (#(remove addedThenRemoved) includes: mAssoc value) ifFalse:
				[messageList add: clAssoc key asString, ' ' , mAssoc key]]].
	^ messageList asArray