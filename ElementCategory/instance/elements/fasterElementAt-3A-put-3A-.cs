fasterElementAt: sym put: element
	"Add symbol at the end of my sorted list and put the element in the dictionary.  This variant adds the key at the end of the keys list without checking whether it already exists."

	keysInOrder add: sym.
	^ elementDictionary at: sym put: element