next: anInteger putAll: aCollection startingAt: startIndex
	"Store the next anInteger elements from the given collection."
	0 to: anInteger-1 do:[:i|
		self nextPut: (aCollection at: startIndex + i).
	].
	^aCollection