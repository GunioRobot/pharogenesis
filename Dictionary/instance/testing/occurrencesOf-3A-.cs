occurrencesOf: anObject 
	"Answer how many of the receiver's elements are equal to anObject."

	| count |
	count := 0.
	self do: [:each | anObject = each ifTrue: [count := count + 1]].
	^count