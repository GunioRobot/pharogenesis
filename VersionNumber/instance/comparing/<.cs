< another 
	"Answer whether the receiver is less than the argument."

	| tmp |
	(self inSameBranchAs: another) ifFalse: 
		[^self error: 'Receiver and argument in different branches'].

	tmp := another numbers.
	(tmp size = numbers size) ifTrue:
		[1 to: numbers size do: 
			[ :in | (numbers at: in) < (tmp at: in) ifTrue: [^true]].
		^false].

	^numbers size < tmp size
