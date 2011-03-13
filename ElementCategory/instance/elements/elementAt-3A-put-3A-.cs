elementAt: sym put: element
	"Add symbol at the end of my sorted list (unless it is already present), and put the element in the dictionary"

	(keysInOrder includes: sym) ifFalse: [keysInOrder add: sym].
	^ elementDictionary at: sym put: element