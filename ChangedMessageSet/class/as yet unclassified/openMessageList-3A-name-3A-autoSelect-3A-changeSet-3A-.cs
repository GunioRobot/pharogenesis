openMessageList: messageList name: labelString autoSelect: autoSelectString changeSet: aChangeSet
	| messageSet |

	messageSet _ self messageList: messageList.
	messageSet changeSet: aChangeSet.
	messageSet autoSelectString: autoSelectString.
	Smalltalk isMorphic
		ifTrue: [self openAsMorph: messageSet name: labelString]
		ifFalse: [ScheduledControllers scheduleActive:  (self open: messageSet name: labelString)]