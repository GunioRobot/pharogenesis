displayCharGatheringParameters: c
	"display a character from the mode #gatheringParameters"

	| colorName |
	c isDigit  ifTrue: [
		"add a digit to the last parameter"
		commandParams at: commandParams size put:
			(commandParams last * 10 + c digitValue).
		^self ].

	c = $; ifTrue: [
		"end of a parameter; begin another one"
		commandParams add: 0.
		^self ].

	c = $m ifTrue: [
		"change display modes"
		displayMode _ #normal.

		commandParams do: [ :p |
			p = 0 ifTrue: [
				"reset"
				foregroundColor _ Color white ].
			(p >= 30 and: [ p <= 37 ]) ifTrue: [
				"change color"
				colorName _ #(gray red green yellow blue blue cyan white) at: (p - 29).
				foregroundColor _ Color perform: colorName. ] ].

		^self ].


	"unrecognized character"
	displayMode _ #normal.
	^self displayChar: c