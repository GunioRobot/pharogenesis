copyUpTo: aCharacter 
	"Answer a copy of the receiver from index 1 to the first occurrence of 
	aCharacter, not including aCharacter."

	| index |
	index _ self indexOf: aCharacter ifAbsent: [^self].
	^self copyFrom: 1 to: index-1