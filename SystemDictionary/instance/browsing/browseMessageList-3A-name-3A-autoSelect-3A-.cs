browseMessageList: messageList name: labelString autoSelect: autoSelectString
	| title aSize |
	"Create and schedule a MessageSet browser on the message list."

	messageList size = 0 ifTrue: 
		[^ (PopUpMenu labels: ' OK ')
				startUpWithCaption: 'There are no
' , labelString].

	title _ (aSize _ messageList size) > 1
		ifFalse:	[labelString]
		ifTrue:	[ labelString, ' [', aSize printString, ']'].

	MessageSet openMessageList: messageList name: title autoSelect: autoSelectString