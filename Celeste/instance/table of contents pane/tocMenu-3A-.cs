tocMenu: aMenu
	"Answer the menu for the table of contents pane."

	| messageSelected |

	currentCategory ifNil: [^ nil].

	messageSelected _ currentMsgID isNil not.

	messageSelected
		ifFalse: [
			aMenu add: 'compose'  action: #compose.
			aMenu balloonTextForLastItem: 'Compose a new message'.
			aMenu addLine.
			]
		ifTrue: [
			aMenu add: 'delete'  action: #deleteMessage.
			aMenu balloonTextForLastItem: 'Move this message to the .trash. category'.
			aMenu addLine.

			aMenu add: 'compose'  action: #compose.
			aMenu balloonTextForLastItem: 'Compose a new message'.
			aMenu add: 'reply'  action: #reply.
			aMenu balloonTextForLastItem: 'Reply to this message'.
			aMenu add: 'forward'  action: #forward.
			aMenu balloonTextForLastItem: 'Forward this message'.
			aMenu addLine.

			lastCategory isEmpty ifFalse: [
				aMenu add: 'file -> ', lastCategory  action: #fileAgain.
				aMenu balloonTextForLastItem: 'Add this message also to the category ', lastCategory.
				aMenu add: 'move -> ', lastCategory  action: #moveAgain.
				aMenu balloonTextForLastItem: 'Move this message to the category ', lastCategory.
				aMenu addLine.
				].

			aMenu add: 'file'  action: #fileMessage.
			aMenu balloonTextForLastItem: 'Add this message also to a different category'.
			aMenu add: 'move'  action: #moveMessage.
			aMenu balloonTextForLastItem: 'Move this message to a different category'.
			aMenu add: 'remove'  action: #removeMessage.
			aMenu balloonTextForLastItem: 'Remove this message from this category
(NB: the message will be safely available in another category)'.
			aMenu addLine.
			].


	"The following are common for all menus"
	aMenu add: 'file all'  action: #fileAll.
	aMenu balloonTextForLastItem: 'Add all messages also to another category'.
	aMenu add: 'move all'  action: #moveAll.
	aMenu balloonTextForLastItem: 'Move all messages to another category'.
	aMenu add: 'remove all'  action: #removeAll.
	aMenu balloonTextForLastItem: 'Remove all messages from this catgegory
(NB: each message will be safely available in other categories)'.
	aMenu add: 'delete all'  action: #deleteAll.
	aMenu balloonTextForLastItem: 'Move all messages to the .trash. category'.
	aMenu addLine.


	messageSelected
		ifTrue: [
			aMenu add: 'other categories'  action: #otherCategories.
			aMenu balloonTextForLastItem: 'Check which other categories also contain this message'.
			aMenu add: 'save message'  action: #saveMessage.
			aMenu balloonTextForLastItem: 'Save this message'.
			aMenu addLine.
			].


	aMenu add: 'search'  action: #search.
	aMenu balloonTextForLastItem: 'Search all messages in this category for something'.

	^ aMenu