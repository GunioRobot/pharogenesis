assertValidMessageAt: filePosition id: msgID
	"Verify that the given filePosition is, indeed, the start of a message (possibly deleted) with the given ID and raise an error if this assertion is false."

	| delimiter fileMsgID |
	"assume file is open"
	file position: filePosition.
	delimiter _ file next: 10.
	((delimiter = '&&&&&start') or: [delimiter = '&&&&&XXXXX']) ifFalse:
		[^self reportInconsistency].
	file next. "skip cr"
	fileMsgID _ MailDB readIntegerLineFrom: file.
	(msgID = fileMsgID) ifFalse:
		[^self reportInconsistency].