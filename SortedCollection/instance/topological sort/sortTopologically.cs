sortTopologically
	"Plenty of room for increased efficiency in this one."

	| remaining result pick |
	remaining _ self asOrderedCollection.
	result _ OrderedCollection new.
	[remaining isEmpty] whileFalse: [
		pick _ remaining select: [:item |
			remaining allSatisfy: [:anotherItem |
				item == anotherItem or: [self should: item precede: anotherItem]]].
		pick isEmpty ifTrue: [self error: 'bad topological ordering'].
		result addAll: pick.
		remaining removeAll: pick].
	^self copySameFrom: result