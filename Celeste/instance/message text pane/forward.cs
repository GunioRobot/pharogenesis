forward
	"Make a MailSendTool for forwarding the current message."

	(currentMsgID notNil) ifTrue:
		[self openSender: (self forwardTextFor: currentMsgID)].