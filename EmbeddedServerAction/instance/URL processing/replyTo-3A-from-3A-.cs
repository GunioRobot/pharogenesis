replyTo: pieces from: request
	(StandardFileStream isAFileNamed: pieces) 
	ifTrue:
		[request reply: PWS success; reply: PWS contentHTML, PWS crlf.
		request reply: (HTMLformatter evalEmbedded:
			(FileStream fileNamed: pieces) contentsOfEntireFile with: request)]
	ifFalse:
		[request error: PWS notFound].

