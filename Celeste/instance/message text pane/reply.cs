reply
	"Make a MailSendTool for replying to the current message."

	(currentMsgID notNil) ifTrue:
		[self openSender: (self replyTextFor: currentMsgID)].