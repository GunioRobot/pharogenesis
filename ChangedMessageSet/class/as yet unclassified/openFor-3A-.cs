openFor: aChangeSet
	"Open up a ChangedMessageSet browser on the given change set; this is a conventional message-list browser whose message list is the list of methods in aChangeSet.  After any method submission, the message list is refigured, making it plausibly dynamic.  "
	| messageSet |

	messageSet _ self messageList: aChangeSet changedMessageListAugmented.
	messageSet changeSet: aChangeSet.
	messageSet autoSelectString: nil.
	ScheduledControllers scheduleActive: 
					(self open: messageSet name:  'Methods in Change Set ', aChangeSet name)