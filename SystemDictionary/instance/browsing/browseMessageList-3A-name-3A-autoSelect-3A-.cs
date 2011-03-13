browseMessageList: messageList name: labelString autoSelect: autoSelectString
	"Create and schedule a MessageSet browser on the  message list.
	1/22/96 sw: add message count to title.
	1/24/96 sw: don't put the msg count in 'there-are-no' msg"
	messageList size = 0 ifTrue: 
		[^ (PopUpMenu labels: ' OK ')
				startUpWithCaption: 'There are no
' , labelString].

	MessageSet openMessageList: messageList name: (labelString, ' [', messageList size printString, ']') autoSelect: autoSelectString