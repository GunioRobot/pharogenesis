do: aBlock
	"For each element in order, evaluate aBlock with two arguments: the element,
	 and whether it is the last element."

	| numElements |
	1 to: (numElements _ elements size) do:
		[:i | aBlock value: (elements at: i) value: i=numElements]