emptyTrash
	"Delete all messages in the '.trash.' category.
	WARNING: The messages will be totally removed from the Celeste index, and the .messages file will be marked so that the message contents are removed when it is next compressed."

	| messagesInTrash messagesOnlyInTrash messagesToDelete |
	mailDB ifNil: [ ^self ].
	self requiredCategory: '.trash.'.

	messagesInTrash _ mailDB messagesIn: '.trash.'.
	messagesOnlyInTrash _ messagesInTrash select: [ :msgID |
		(mailDB categoriesThatInclude: msgID) size = 1].
	(messagesOnlyInTrash size < messagesInTrash size and: [
		(SelectionMenu confirm: 'Some messages are also filed in other categories.
Do you want to delete them anyway?')])
			ifTrue: [messagesToDelete _ messagesInTrash]
			ifFalse: [messagesToDelete _ messagesOnlyInTrash].

	mailDB deleteAll: messagesToDelete.
	self updateTOC.
	self synchronizeToDisk.