down
	"move down the context stack to the previous (enclosing) context"

	| index |
	index _ model contextStackIndex.
	model toggleContextStackIndex: index+1