addAll: aCollection
	aCollection do: [:each | 
		self isFull ifTrue: [^ self].
		self add: each.
	].