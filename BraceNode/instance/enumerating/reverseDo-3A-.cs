reverseDo: aBlock
	"For each element in reverse order, evaluate aBlock with two arguments: the element,
	 and whether it is the last element."

	| numElements |
	(numElements _ elements size) to: 1 by: -1 do:
		[:i | aBlock value: (elements at: i) value: i=numElements]