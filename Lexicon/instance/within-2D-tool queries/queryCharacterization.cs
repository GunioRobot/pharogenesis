queryCharacterization
	"Answer a characterization of the most recent query"

	currentQuery == #selectorName
		ifTrue: [^ 'My methods whose names include "', self lastSearchString, '"'].
	currentQuery == #methodsWithInitials
		ifTrue: [^ 'My methods stamped with initials ', currentQueryParameter].
	currentQuery == #senders
		ifTrue: [^ 'My methods that send #', self lastSendersSearchSelector].
	currentQuery == #currentChangeSet
		ifTrue: [^ 'My methods in the current change set'].
	currentQuery == #instVarRefs
		ifTrue:	[^ 'My methods that refer to instance variable "', currentQueryParameter, '"'].
	currentQuery == #instVarDefs
		ifTrue:	[^ 'My methods that store into instance variable "', currentQueryParameter, '"'].
	currentQuery == #classVarRefs
		ifTrue:	[^ 'My methods that refer to class variable "', currentQueryParameter, '"'].
	^ 'Results of queries will show up here'