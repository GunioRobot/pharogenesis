printOn: aStream indent: level

	(key isVariableBinding)
		ifTrue:
			[key key isNil
				ifTrue:
					[aStream nextPutAll: '###';
					 	nextPutAll: key value soleInstance name]
				ifFalse:
					[aStream nextPutAll: '##';
						nextPutAll: key key]]
		ifFalse:
			[aStream withStyleFor: #literal
					do: [key storeOn: aStream]]