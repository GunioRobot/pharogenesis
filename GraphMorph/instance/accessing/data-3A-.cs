data: aCollection

	data _ aCollection.
	maxVal _ minVal _ 0.
	data do: [:x |
		x < minVal ifTrue: [minVal _ x].
		x > maxVal ifTrue: [maxVal _ x]].

	self flushCachedForm.
