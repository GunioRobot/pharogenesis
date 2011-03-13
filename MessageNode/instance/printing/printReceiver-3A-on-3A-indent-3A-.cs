printReceiver: rcvr on: aStream indent: level
					
	rcvr ifNil: [^ self].

	"Force parens around keyword receiver of kwd message"
	(precedence = 3 and: [aStream dialect = #SQ00])
		ifTrue: [rcvr printOn: aStream indent: level precedence: precedence - 1]
		ifFalse: [rcvr printOn: aStream indent: level precedence: precedence]
