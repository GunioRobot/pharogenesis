replyTextFor: msgID
	"Answer the template for a reply to the message with the given ID."

	| msg s anyCCs replyaddress |
	msg _ mailDB getMessage: msgID.
	s _ WriteStream on: (String new: 500).

	"add From:"
	s nextPutAll: 'From: ', Celeste userName; cr.


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
	(Celeste ccList isEmpty) ifFalse: [
		anyCCs ifTrue: [ s nextPutAll: ', ' ] ifFalse: [ anyCCs _ true ].	
		s nextPutAll: Celeste ccList ].
	s cr.


	"add contents of previous message"
	s cr.
	s nextPutAll: msg from; nextPutAll: ' wrote:'; cr.
	msg bodyText linesDo: [ :line |
		s nextPutAll: '> '.
		s nextPutAll: line.
		s cr ].
	s cr.

	^s contents