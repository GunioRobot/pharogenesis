upToEnd

	| newStream element |
	collection _ self isBinary
				ifTrue: [ByteArray new: 100]
				ifFalse: [String new: 100].
	newStream _ WriteStream on: collection.
	[(element _ self next) notNil]
		whileTrue: [newStream nextPut: element].
	^ newStream contents
