whichSelectorsReferTo: literal 
	"Answer a Set of selectors whose methods access the argument as a
literal."

	| special byte |
	special _ self environment hasSpecialSelector: literal ifTrueSetByte: [:b |
byte _ b].
	^self whichSelectorsReferTo: literal special: special byte: byte

	"Rectangle whichSelectorsReferTo: #+."