sortBy: aBlock
	"Create a copy that is sorted.  Sort criteria is the block that accepts two arguments.  When the block is true, the first arg goes first ([:a :b | a > b] sorts in descending order)."
	| sorted other |
	sorted _ (SortedCollection sortBlock: aBlock) addAll: self.
	other _ self copy.
	1 to: self size do: [:index |  other at: index put: 
		(sorted at: index)].
	^ other