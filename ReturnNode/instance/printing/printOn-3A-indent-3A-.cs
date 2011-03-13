printOn: aStream indent: level

	aStream dialect = #SQ00
		ifTrue: ["Add prefix keyword"
				aStream withStyleFor: #setOrReturn do: [aStream nextPutAll: 'Answer '].
				expr printOn: aStream indent: level]
		ifFalse: [aStream nextPutAll: '^ '.
				expr printOn: aStream indent: level].
	expr printCommentOn: aStream indent: level.
