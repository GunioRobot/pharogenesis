doWithIndex: aBlock2
	"Support Set enumeration with a counter, even though not ordered"
	| index |
	index _ 0.
	self do: [:item | aBlock2 value: item value: (index _ index+1)]