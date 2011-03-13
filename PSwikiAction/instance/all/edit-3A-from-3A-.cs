edit: pageRef from: request
	"Check authorization"
	(pageRef privs includesSubString: 'write') ifTrue:
		[(authorizer user: request userID) = pageRef coreID
		ifFalse: [self error: (PWS unauthorizedFor: authorizer realm)]].
	request reply: PWS success; reply: PWS contentHTML.
	request reply: PWS crlf.
request reply: (HTMLformatter evalEmbedded: 
							(self fileContents: source , 'pedit.html')
						with: pageRef).
	pageRef noteEditRequest.
	^ self