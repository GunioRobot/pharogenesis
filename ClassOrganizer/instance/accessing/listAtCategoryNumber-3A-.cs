listAtCategoryNumber: anInteger 
	"Answer the array of elements stored at the position indexed by 
	anInteger."

	| firstIndex lastIndex |
	firstIndex _ 
		(anInteger > 1
			ifTrue: [categoryStops at: anInteger - 1]
			ifFalse: [0])
		+ 1.
	lastIndex _ categoryStops at: anInteger.
	^elementArray copyFrom: firstIndex to: lastIndex