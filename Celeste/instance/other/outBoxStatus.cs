outBoxStatus
	| outgoing |
	outgoing _ mailDB ifNil: [ #() ] ifNotNil: [ mailDB messagesIn: '.tosend.' ].
	outgoing isEmpty
		ifTrue: [^ 'no mail to be sent'].
	^ 'messages in queue: ' , outgoing size printString