next: anInteger putAll: aCollection startingAt: startIndex
	"Store the next anInteger elements from the given collection."


	| newEnd |
	collection class == aCollection class ifFalse:
		[^ super next: anInteger putAll: aCollection startingAt: startIndex].

	newEnd _ position + anInteger.
	newEnd > writeLimit ifTrue:
		[self growTo: newEnd + 10].

	collection replaceFrom: position+1 to: newEnd  with: aCollection startingAt: startIndex.
	position _ newEnd.

	^aCollection