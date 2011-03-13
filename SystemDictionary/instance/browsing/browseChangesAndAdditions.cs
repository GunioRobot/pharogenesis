browseChangesAndAdditions
	"Create and schedule a message browser on each method that has been changed, as well as on any method belonging to an added class.  1/18/96 sw"

	"Smalltalk browseChangesAndAdditions"
	^ self 
		browseMessageList: SystemChanges changedMessageList asArray, SystemChanges allMessagesForAddedClasses asArray
		name: 'New and Changed Methods'