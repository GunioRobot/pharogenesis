assertValidMessageAt: filePosition id: msgID
	"Verify that the given filePosition is, indeed, the start of a valid undeleted message with the given ID and raise an error if this assertion is false."

	| delimiter fileMsgID |
	"assume file is open"

	file position: filePosition.

	delimiter _ file next: 11.
	(delimiter = ('&&&&&start', String cr)) ifFalse:
		[self reportInconsistency. ^false].

	fileMsgID _ MailDB readIntegerLineFrom: file.
	(msgID = fileMsgID) ifFalse:
		[self reportInconsistency. ^false].

	^true.