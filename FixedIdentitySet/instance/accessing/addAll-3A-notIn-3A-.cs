addAll: aCollection notIn: notCollection
	aCollection do: [:each | 
		self isFull ifTrue: [^ self].
		(notCollection includes: each) ifFalse: [self add: each].
	].