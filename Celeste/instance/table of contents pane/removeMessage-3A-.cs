removeMessage: msgID
	"Remove the message from the current category and update the display"

	| currentMessageIndex newMsgID |

	msgID ifNil: [^ self].
	self category ifNil: [ ^self ].
	[currentMessages includes: msgID] assert.

	mailDB remove: msgID fromCategory: self category.

	"remove the message from the listing"
	currentMessageIndex _ currentMessages indexOf: msgID.
	currentMessages _ currentMessages copyWithout: msgID.

	"update the message index and message ID"
	currentMessages isEmpty
		ifTrue: [newMsgID _ nil]
		ifFalse: [newMsgID _ currentMessages
					at: (currentMessageIndex min: currentMessages size)].
	newMsgID ifNotNil: [[currentMessages includes: newMsgID] assert].

	self displayMessage: newMsgID.

	self changed: #tocEntryList.
	self changed: #tocEntryListAsStrings.
	self changed: #outBoxStatus