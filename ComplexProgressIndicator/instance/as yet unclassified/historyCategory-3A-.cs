historyCategory: aKey

	History ifNil: [History _ Dictionary new].
	specificHistory _ History
		at: aKey
		ifAbsentPut: [Dictionary new].
	^specificHistory
