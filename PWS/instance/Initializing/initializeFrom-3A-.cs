initializeFrom: aSocket
	"Initialize me from aSocket."
	| request idx |
	log _ WriteStream on: ''.
	connection _ aSocket.
	request _ self readRequest.	"sets header"
	header _ header substrings.
	url _ self unEscape: (header at: 2).
	((idx _ header indexOf: 'Authorization:') ~= 0 and: [(header at:
idx + 1)
			= 'Basic'])
		ifTrue: [userId _ header at: idx + 2].

	peerName _ self clientName: connection remoteAddress.

	log
		nextPutAll: Time totalSeconds asString; tab;
		nextPutAll: peerName asString; tab;
		nextPutAll: userId asString; tab;
		nextPutAll: url; tab;
		nextPutAll: request last asString; tab.

	request last notNil
		ifTrue: [ fields := self decodeFields: request last ]
		ifFalse: [ (url includes: $?) ifTrue: [
			idx _ url indexOf: $?.
			idx = url size
				ifTrue: [ "empty request" fields _
Dictionary new ]
				ifFalse: [
					fields _ self decodeFields:
						(url copyFrom: idx+1 to:
url size) ].
			url _ url copyFrom: 1 to: idx-1 ] ].

	message := url findTokens: '/.\?:='.
