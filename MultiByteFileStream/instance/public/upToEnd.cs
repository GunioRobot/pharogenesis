upToEnd

	| newStream element |
	collection := self isBinary
				ifTrue: [ByteArray new: 100]
				ifFalse: [String new: 100].
	newStream := collection writeStream.
	[(element := self next) notNil]
		whileTrue: [newStream nextPut: element].
	^ newStream contents
