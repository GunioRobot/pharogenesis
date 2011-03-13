changedClassNames
	"Answer a OrderedCollection of the names of changed or edited classes.  DOES include removed classes.  Sort alphabetically."

	| classes |
	classes _ SortedCollection new: (methodChanges size + classChanges size) *2.
	methodChanges keys do: [:className | classes add: className].
	classChanges keys do: [:className | 
		(methodChanges includesKey: className) ifFalse: [
			"avoid duplicates, faster than (classes addIfNotPresent: xx)"
			classes add: className]].
	classRemoves do: [:className | classes addIfNotPresent: className].
	^ classes asOrderedCollection