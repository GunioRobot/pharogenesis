selectorsRetrieved
	"Anwer a list of selectors in the receiver that have been retrieved for the query category.  This protocol is used when reformulating a list after, say, a limitClass change"

	currentQuery == #classVarRefs ifTrue: [^ self selectorsReferringToClassVar].
	currentQuery == #currentChangeSet ifTrue: [^ self selectorsChanged].
	currentQuery == #instVarDefs ifTrue: [^ self selectorsDefiningInstVar].
	currentQuery == #instVarRefs ifTrue: [^ self selectorsReferringToInstVar].
	currentQuery == #methodsWithInitials ifTrue: [^ self methodsWithInitials].
	currentQuery == #selectorName ifTrue: [^ self selectorsMatching].
	currentQuery == #senders ifTrue: [^ self selectorsSendingSelectedSelector].

	^ #()