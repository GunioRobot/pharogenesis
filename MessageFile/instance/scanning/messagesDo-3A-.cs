messagesDo: aBlock
	"Scan the message file and invoke the given block for each message in it. The block arguments are:
	deleted			true if this message is marked deleted
	msgID			the message ID
	msgBody			the message text
This operation is very expensive."

	| more deleted msgID textStart textSize msgBody |
	self ensureFileIsOpen.
	file position: 0.
	more _ self scanToNextMessageIn: file.
	[more] whileTrue:
		[deleted _								"deleted"
			(MailDB readStringLineFrom: file) = '&&&&&XXXXX'.
		 msgID _ MailDB readIntegerLineFrom: file.	"msgID"
		 textStart _ file position.
		 more _ self scanToNextMessageIn: file.
		 textSize _ file position - textStart.
		 file position: textStart.
		 msgBody _ file next: textSize.				"msgBody"
		 aBlock valueWithArguments:
			(Array
				with: deleted
				with: msgID
				with: msgBody)].