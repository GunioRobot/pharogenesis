= aHeap
	"Answer true if my and aHeap's species are the same,
	and if our blocks are the same, and if our elements are the same."

	self species = aHeap species ifFalse: [^ false].
	sortBlock = aHeap sortBlock
		ifTrue: [^ super = aHeap]
		ifFalse: [^ false]