appendValue: aPointOrNumber

	| newVal |
	(data isKindOf: OrderedCollection) ifFalse: [data _ data asOrderedCollection].
	newVal _ self asNumber: aPointOrNumber.
	data addLast: newVal.
	newVal < minVal ifTrue: [minVal _ newVal].
	newVal > maxVal ifTrue: [maxVal _ newVal].
	self cursor: data size.
	self flushCachedForm.
