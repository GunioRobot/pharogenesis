selectorsVisited
	"Answer the list of selectors visited in this tool"

	^ selectorsVisited ifNil: [selectorsVisited _ OrderedCollection new]