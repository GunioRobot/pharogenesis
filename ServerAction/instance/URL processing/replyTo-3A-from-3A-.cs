replyTo: pieces from: request
	Transcript show: 'Now replying with: ', pieces; cr.
	(StandardFileStream isAFileNamed: pieces) 
	ifTrue:
		[request reply: PWS success; reply: PWS contentHTML, PWS crlf.
		request reply: (FileStream fileNamed: pieces) contentsOfEntireFile]
	ifFalse:
		[request error: PWS notFound].

