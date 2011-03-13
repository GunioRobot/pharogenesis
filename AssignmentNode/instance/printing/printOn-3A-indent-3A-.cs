printOn: aStream indent: level

	aStream dialect = #SQ00
		ifTrue: [aStream withStyleFor: #setOrReturn do: [aStream nextPutAll: 'Set '].
				variable printOn: aStream indent: level.
				aStream withStyleFor: #setOrReturn do: [aStream nextPutAll: ' to '].
				value printOn: aStream indent: level + 2]
		ifFalse: [variable printOn: aStream indent: level.
				aStream nextPutAll: ' _ '.
				value printOn: aStream indent: level + 2]