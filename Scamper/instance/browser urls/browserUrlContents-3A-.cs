browserUrlContents: aRequest
	aRequest = 'start' ifTrue: [ 
		^MIMEDocument contentType: 'text/html' content: self startPage ].

	^ nil