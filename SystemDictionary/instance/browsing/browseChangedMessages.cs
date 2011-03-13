browseChangedMessages
	"Create and schedule a message browser on each method that has been 
	changed."

	^self 
		browseMessageList: SystemChanges changedMessageListAugmented 
		name: 'Changed Messages'