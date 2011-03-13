changedMessageList
	"Used by a message set browser to access the list view information."

	| messageList |
	messageList _ SortedCollection new.
	methodChanges associationsDo: 
		[:clAssoc | 
		clAssoc value associationsDo: 
			[:mAssoc |
			mAssoc value = #remove ifFalse:
				[messageList add: clAssoc key asString, ' ' , mAssoc key]]].
	^messageList asArray