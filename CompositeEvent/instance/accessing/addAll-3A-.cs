addAll: aCollection
	aCollection do: [ :each | self add: each].
	^ aCollection