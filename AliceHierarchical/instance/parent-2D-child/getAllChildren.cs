getAllChildren
	"Return all of this instance's children"

	| children |

	children _ OrderedCollection new.

	myChildren do: [:child | children addLast: child.
						children _ children , (child getAllChildren).
					].

	^ children.