replyTo: pieces from: request
	| theLast |
	(StandardFileStream isAFileNamed: pieces)
		ifTrue:
			[theLast _ request message last asLowercase.
			theLast = 'gif' ifTrue: [^ self process: request MIMEtype: 'image/gif'].
			theLast = 'jpeg' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
			theLast = 'jpg' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
			theLast = 'jpe' ifTrue: [^ self process: request MIMEtype: 'image/jpeg'].
			request reply: PWS success;
			 reply: PWS contentHTML , PWS crlf.
			request reply: (HTMLformatter evalEmbedded: 
				(FileStream fileNamed: pieces) contentsOfEntireFile with: request)]
		ifFalse: [request error: PWS notFound]