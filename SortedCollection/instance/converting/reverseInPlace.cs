reverseInPlace
	"Change this colleciton into its reversed.
	Do not make a copy like reversed do, but change self in place."
	
	| newFirstIndex oldSortBlock |
	newFirstIndex := 1 + array size - lastIndex.
	lastIndex := 1 + array size - firstIndex.
	firstIndex := newFirstIndex.
	array := array reversed.
	oldSortBlock := (sortBlock ifNil: [[:a :b | a <= b]]) copy.
	sortBlock := [:a :b | oldSortBlock value: b value: a] fixTemps