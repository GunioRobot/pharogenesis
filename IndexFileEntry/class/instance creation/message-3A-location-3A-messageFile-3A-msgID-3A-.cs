message: aMailMessage location: location messageFile: aMessageFile msgID: msgID
	"Answer a new instance of me for the given message and message file location."

	^self new
		messageFile: aMessageFile;
		msgID: msgID;
		location: location;
		textLength: aMailMessage text size;
		time: aMailMessage time;
		from: aMailMessage from;
		to: aMailMessage to;
		cc: aMailMessage cc;
		subject: aMailMessage subject