appendChildrenNamesTo: prefix
	"Return the object's children's names, each appended to the prefix."

	| nameList |

	nameList _ OrderedCollection new.
	myChildren do: [:child |
						(child appearsInChildLists) ifTrue: [
							nameList addLast: (prefix , (child getName)).
							nameList _ nameList , (child appendChildrenNamesTo: (prefix , '    '))].
					].
	^ nameList.
