replyTextFor: msgID
	"Answer the template for a reply to the message with the given ID."

	| msg s anyCCs replyaddress |
	msg _ mailDB getMessage: msgID.
	s _ WriteStream on: (String new: 500).

	"add From:"
	s nextPutAll: 'From: ', self account userName; cr.


	"add Subject:"
	((msg subject asLowercase indexOfSubCollection: 're:' startingAt: 1) ~= 0)
		ifTrue: [s nextPutAll: 'Subject: ', msg subject]
		ifFalse: [s nextPutAll: 'Subject: Re: ', msg subject].
	s cr.


	"add To:"
	"Use the Reply-To: address if there is one, otherwise the From: address"
	replyaddress _ msg from.
	msg headerFieldsNamed: 'reply-to' do: [ :destAdd | replyaddress _ destAdd ].
	s nextPutAll: 'To: ', replyaddress; cr.
	

	"add CC:s from the message and from the user's CC list"
	s nextPutAll: 'CC: '.
	anyCCs _ false.
	(msg to isEmpty) ifFalse: [
		anyCCs ifTrue:[ s nextPutAll: ', '] ifFalse: [ anyCCs _ true ].
		s nextPutAll: msg to ].
	(msg cc isEmpty) ifFalse: [
		anyCCs ifTrue: [ s nextPutAll: ', ' ] ifFalse: [ anyCCs _ true ].
		s nextPutAll: msg cc ].
	(self account ccList isEmpty) ifFalse: [
		anyCCs ifTrue: [ s nextPutAll: ', ' ] ifFalse: [ anyCCs _ true ].	
		s nextPutAll: self account ccList ].
	s cr.

	"add In-Reply-To and References"
	(msg hasFieldNamed: 'message-id') ifTrue: [
		| replyTo references |
		replyTo := (msg fieldNamed: 'message-id') mainValue.
		(msg hasFieldNamed: 'references')
			ifTrue: [ references := (msg fieldNamed: 'references') mainValue, String cr, ' ' ]
			ifFalse:[ references := '' ].
		references := references, replyTo.

		s nextPutAll: 'In-Reply-To: '; nextPutAll: replyTo; cr.
		s nextPutAll: 'References: '; nextPutAll: references; cr.
	].


	"add contents of previous message"
	s cr.
	s nextPutAll: msg from; nextPutAll: ' wrote:'; cr.
	msg formattedText asString linesDo: [ :line |
		s nextPutAll: '> '.
		s nextPutAll: line.
		s cr ].
	s cr.

	^s contents