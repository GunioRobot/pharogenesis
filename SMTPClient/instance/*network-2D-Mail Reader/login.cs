login
	"self user ifNil: [^self].??"
	"GG Bug fix: we must FIRST say hello, even if no user is specified"
	self sendCommand: 'EHLO aSqueakSystem'.
	self checkResponse.
	self user ifNil: [
		Transcript show:'SMTPClient: warn you do not have a username: no auth on smtp will be done'; cr.
		^self].	
	self sendCommand: 'AUTH LOGIN ' , ((self encodeString: self user) reject: [:c | c asciiValue = 0]).
	[self checkResponse]
		on: TelnetProtocolError
		do: [ :ex | ex isCommandUnrecognized ifTrue: [^ self] ifFalse: [ex pass]].
	self sendCommand: ((self encodeString: self password) reject: [:c | c asciiValue = 0]).
	self checkResponse