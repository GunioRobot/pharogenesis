emptyTrash
	"Delete all messages in the '.trash.' category.
	WARNING: The messages will be totally removed from the Celeste index, and the .messages file will be marked so that the message contents are removed when it is next compressed."

	| msgList |

	self requiredCategory: '.trash.'.

	msgList _ mailDB messagesIn: '.trash.'.			"Look at ALL messages in the trash"
	"Remove from the list messages which are also in other categories"
	msgList _ msgList select: [ :msgID | (mailDB categoriesThatInclude: msgID) size = 1].

	mailDB deleteAll: msgList.
	mailDB cleanUpCategories.
	self updateTOC.

	(mailDB messagesIn: '.trash.') isEmpty ifFalse:
		[self inform: 'Some messages were not removed because they are also filed in other categories'].