printOn: aStream indent: level

	(key isMemberOf: Association)
		ifTrue:
			[key key isNil
				ifTrue:
					[aStream nextPutAll: '###';
					 	nextPutAll: key value soleInstance name]
				ifFalse:
					[aStream nextPutAll: '##';
						nextPutAll: key key]]
		ifFalse:
			[aStream withAttributes: (Preferences syntaxAttributesFor: #literal) do:  [key storeOn: aStream]]