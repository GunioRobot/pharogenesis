up
	"move up the context stack to the next (enclosed) context"

	| index |
	index _ model contextStackIndex.
	index > 1 ifTrue: [model toggleContextStackIndex: index-1]