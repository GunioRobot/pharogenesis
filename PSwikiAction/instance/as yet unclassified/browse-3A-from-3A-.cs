browse: pageRef from: request
	"Check authorization"
	(pageRef privs includesSubString: 'read') ifTrue:
		[(authorizer user: request userID) = pageRef coreID
		ifFalse: [self error: (PWS unauthorizedFor: authorizer realm)]].
	request reply: PWS success; reply: PWS contentHTML.
	request reply: PWS crlf.
	^super browse: pageRef from: request
