selectorsVisited
	"Answer the list of selectors visited in this tool"

	^ selectorsVisited ifNil: [selectorsVisited := OrderedCollection new]