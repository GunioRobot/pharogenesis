listAtCategoryNumber: anInteger 
	"Answer the array of elements stored at the position indexed by anInteger.  Answer nil if anInteger is larger than the number of categories."

	| firstIndex lastIndex |
	firstIndex _ 
		(anInteger > 1
			ifTrue: [categoryStops at: anInteger - 1]
			ifFalse: [0])
		+ 1.
	(categoryStops size < anInteger) ifTrue:
		[^ nil].  "It can happen, if Default category got aggressively removed by some automatic operation"
	lastIndex _ categoryStops at: anInteger.
	^elementArray copyFrom: firstIndex to: lastIndex