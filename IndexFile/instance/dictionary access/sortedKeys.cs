sortedKeys
	"Answer a collection of message IDs for the messages in this IndexFile, sorted in ascending timestamp order. Because sorting is expensive, the sorted key list is cached."

	| keys |
	keys _ OrderedCollection new: timeSortedEntries size * 2.
	timeSortedEntries do: [: assoc | keys addLast: assoc key].
	^keys