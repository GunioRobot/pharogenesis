browserPrintStringWith: anObject 
	| stream |
	stream _ WriteStream
				on: (String new: 100).
	stream nextPut: $(.
	priority printOn: stream.
	self isSuspended
		ifTrue: [stream nextPut: $s].
	stream nextPutAll: ') '.
	stream
		nextPutAll: ((self respondsTo: #processName)
				ifTrue: [self processName]
				ifFalse: [self hash asString forceTo: 5 paddingStartWith: $ ]).
	stream space.
	stream nextPutAll: anObject asString.
	^ stream contents