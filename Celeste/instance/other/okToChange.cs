okToChange
	"This message is sent when changing the selection in either the message cateory or message list panes. Eventually, this should ask the user if it is okay to throw away and unaccepted edits of the current message. For now, it always gives permission."

	currentCategory isNil | currentMsgID isNil ifTrue: [
		"no message selected; discard edits in message pane silently"
		messageTextView hasUnacceptedEdits: false.
		^ true].

	messageTextView hasUnacceptedEdits ifFalse: [^ true].
	(CustomMenu confirm: 'Discard changes to currently selected message?')
		ifTrue: [messageTextView hasUnacceptedEdits: false. ^ true]
		ifFalse: [^ false].
