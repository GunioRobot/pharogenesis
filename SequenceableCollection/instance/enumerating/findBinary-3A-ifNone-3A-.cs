findBinary: aBlock ifNone: exceptionBlock
	"Search for an element in the receiver using binary search.
	The argument aBlock is a one-element block returning
		0 	- if the element is the one searched for
		<0	- if the search should continue in the first half
		>0	- if the search should continue in the second half
	If no matching element is found, evaluate exceptionBlock."
	| index low high test item |
	low _ 1.
	high _ self size.
	[index _ high + low // 2.
	low > high] whileFalse:[
		test _ aBlock value: (item _ self at: index).
		test = 0 
			ifTrue:[^item]
			ifFalse:[test > 0
				ifTrue: [low _ index + 1]
				ifFalse: [high _ index - 1]]].
	^exceptionBlock value