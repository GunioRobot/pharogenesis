sortedElements
	"Answer with a collection of elements with counts, sorted by element."

	| elements |
	elements := SortedCollection new.
	contents associationsDo: [:assn | elements add: assn].
	^elements