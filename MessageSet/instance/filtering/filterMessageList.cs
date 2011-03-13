filterMessageList
	"Allow the user to refine the list of messages."

	| aMenu evt |
	Smalltalk isMorphic ifFalse: [^ self inform: 'sorry, morphic only at this time.'].
	messageList size <= 1 ifTrue: [^ self inform: 'this is not a propitious filtering situation'].

	"would like to get the evt coming in but thwarted by the setInvokingView: circumlocution"
	evt _ self currentWorld activeHand lastEvent.
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addTitle: 'Filter by only showing...'.
	aMenu addStayUpItem.

	aMenu addList: #(
		('messages that send...'					filterToSendersOf)
		-
		('messages in current change set'		filterToCurrentChangeSet)
		('messages not in current change set'	filterToNotCurrentChangeSet)
		('messages in any change set'			filterToAnyChangeSet)
		-
		('messages authored by me'				filterToCurrentAuthor)
		('messages not authored by me'			filterToNotCurrentAuthor)
		-
		('messages only in .changes file'		filterToMessagesInChangesFile)
		('messages with prior versions'			filterToMessagesWithPriorVersions)
			).

	aMenu popUpEvent: evt hand lastEvent in: evt hand world.