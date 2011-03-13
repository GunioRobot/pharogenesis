tempNamesString
	"Decompress the encoded temp names into a schematicTempNames string."
	| sz flagByte |
	flagByte := self at: (sz := self size).
	(flagByte = 0 or: [flagByte > 251]) ifTrue: [^self error: 'not yet implemented'].
	(flagByte = 251
	 and: [(1 to: 3) allSatisfy: [:i | (self at: self size - i) = 0]]) ifTrue:
		[^self error: 'not yet implemented'].
	^self qDecompressFrom: (flagByte <= 127
								ifTrue:
									[ReadStream on: self from: sz - flagByte to: sz - 1]
								ifFalse:
									[ReadStream on: self from: sz - (flagByte - 128 * 128 + (self at: sz - 1)) - 1 to: sz - 2])