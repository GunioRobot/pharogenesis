replyTo: pieces from: request

	"Transcript show: 'Reply: ', pieces; cr."
	(StandardFileStream isAFileNamed: pieces) 
		ifTrue: [
			request reply: PWS success; 
				reply: (PWS content: (MIMEDocument guessTypeFromName: pieces)),
					 PWS crlf.
			request reply: (FileStream fileNamed: pieces) contentsOfEntireFile]
		ifFalse: [
			request error: PWS notFound].
