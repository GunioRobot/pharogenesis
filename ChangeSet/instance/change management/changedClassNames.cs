changedClassNames
	"Answer a OrderedCollection of the names of changed or edited classes.  Not including removed classes.  Sort alphabetically."

	| classes |
	classes _ SortedCollection new: (methodChanges size + classChanges size) *2.
	methodChanges keys do: [:className | classes add: className].
	classChanges keys do: [:className | 
		(methodChanges includesKey: className) ifFalse: [
			"avoid duplicates"
			classes add: className]].
	^ classes asOrderedCollection