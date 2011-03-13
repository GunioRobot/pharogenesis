loadingHistoryDataForKey: anObject

	| answer |
	answer _ specificHistory 
		at: anObject
		ifAbsentPut: [OrderedCollection new].
	answer size > 50 ifTrue: [
		answer _ answer copyFrom: 25 to: answer size.
		specificHistory at: anObject put: answer.
	].
	^answer

