indexForInserting: xValue
	"Return the appropriate index for inserting the given x value"
	| index low high |
	low _ 1.
	high _ tally.
	[index _ high + low // 2.
	low > high]
		whileFalse:[
			(array at: index) xValue <= xValue
				ifTrue: [low _ index + 1]
				ifFalse: [high _ index - 1]].
	^low