largerIndexOf: aFraction in: anArray
	"Find the index of the given fraction in anArray"
	| index low high |
	(lastIndex == nil) ifTrue:[
		"Search entire array"
		low _ 1.
		high _ anArray size.
	] ifFalse:[
		"Unroll the first test for a quick hit of small fractional changes"
		(anArray at: lastIndex) >= aFraction ifTrue:[
			(anArray at: lastIndex - 1) <= aFraction 
				ifTrue:[^lastIndex]
				ifFalse:[	high _ lastIndex-1]. "No need to look further"
		] ifFalse:[
			low _ lastIndex. "No need to look further"
		].
	].
		
	[index _ high + low // 2.
	low > high]
		whileFalse:[
			(anArray at: index) <= aFraction
				ifTrue: [low _ index + 1]
				ifFalse: [high _ index - 1]].
	^lastIndex _ low