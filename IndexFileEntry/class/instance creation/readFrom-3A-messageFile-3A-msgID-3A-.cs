readFrom: aStream messageFile: aMessageFile msgID: msgID
	"Answer a new instance of me initialized from the given text stream."

	^(self new readFrom: aStream)
		messageFile: aMessageFile;
		msgID: msgID