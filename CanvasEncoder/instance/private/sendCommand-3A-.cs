sendCommand: stringArray

	| bucket |
	connection ifNil: [ ^self ].
	connection isConnected ifFalse: [ ^self ].
	connection nextPut: stringArray.
	
	SentTypesAndSizes ifNil: [^self].
	bucket _ SentTypesAndSizes at: stringArray first ifAbsentPut: [{0. 0. 0}].
	bucket at: 1 put: (bucket at: 1) + 1.
	bucket at: 2 put: (bucket at: 2) + (
		stringArray inject: 4 into: [ :sum :array | sum + (array size + 4) ]
	).


	