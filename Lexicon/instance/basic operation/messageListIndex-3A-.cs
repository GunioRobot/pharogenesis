messageListIndex: anIndex
	"Set the message list index as indicated, and update the history list if appropriate"

	| newSelector current |
	current := self selectedMessageName.
	super messageListIndex: anIndex.
	anIndex = 0 ifTrue: [
		self editSelection: #newMessage.
		self contentsChanged].
	(newSelector := self selectedMessageName) ifNotNil: 
		[self updateSelectorsVisitedfrom: current to: newSelector]