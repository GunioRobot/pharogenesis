getAllParts
	"Return all of this actor's parts"

	| parts |

	parts _ OrderedCollection new.

	myChildren do: [:child | (child isPart) ifTrue: [
						parts addLast: child.
						parts _ parts , (child getAllParts).
												].
					].

	^ parts.

	