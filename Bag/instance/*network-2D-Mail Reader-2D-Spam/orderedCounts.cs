orderedCounts
	"Answer with a collection of counts with elements, sorted by decreasing
	count.
	Similar to sortedCounts, but:
	(a) returns an Array
	(b) uses Array's merge sort rather than SortedCollection's heap sort"
	| idx sortedCounts |

	sortedCounts := Array new: contents size.
	idx := 1.
	contents associationsDo: [:assoc |
		sortedCounts at: idx put: (Association key: assoc value value: assoc key).
		idx := idx + 1
	].
	sortedCounts sort: [:x :y | x >= y].
	^sortedCounts