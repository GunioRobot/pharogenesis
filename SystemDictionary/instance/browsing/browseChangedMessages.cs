browseChangedMessages
	"Create and schedule a message browser on each method that has been 
	changed."

	SystemChanges isEmpty ifTrue: [^ self inform: 'There are no changed messages
in the current change set.'].
	ChangedMessageSet openFor: SystemChanges