okToChange
	"This message is sent when changing the selection in either the message cateory or message list panes."

	currentMsgID isNil ifTrue: [
		"no message selected; discard edits in message pane silently"
		messageTextView hasUnacceptedEdits: false.
		^ true].

	messageTextView hasUnacceptedEdits ifFalse: [^ true].
	(CustomMenu confirm: 'Discard changes to currently selected message?')
		ifTrue: [messageTextView hasUnacceptedEdits: false. ^ true]
		ifFalse: [^ false].
