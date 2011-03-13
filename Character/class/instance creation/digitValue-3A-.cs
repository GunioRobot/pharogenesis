digitValue: x 
	"Answer the Character whose digit value is x. For example, answer $9 for 
	x=9, $0 for x=0, $A for x=10, $Z for x=35."

	| index |
	index := x asInteger.
	^CharacterTable at: 
		(index < 10
			ifTrue: [48 + index]
			ifFalse: [55 + index])
		+ 1