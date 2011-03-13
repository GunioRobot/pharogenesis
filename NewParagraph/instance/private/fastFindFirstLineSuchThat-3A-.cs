fastFindFirstLineSuchThat: lineBlock
	"Perform a binary search of the lines array and return the index
	of the first element for which lineBlock evaluates as true.
	This assumes the condition is one that goes from false to true for
	increasing line numbers (as, eg, yval > somey or start char > somex).
	If lineBlock is not true for any element, return size+1."
	| index low high |
	low _ 1.
	high _ lines size.
	[index _ high + low // 2.
	low > high]
		whileFalse: 
			[(lineBlock value: (lines at: index))
				ifTrue: [high _ index - 1]
				ifFalse: [low _ index + 1]].
	^ low