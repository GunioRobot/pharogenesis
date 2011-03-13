numberAtCursor
	"Answer the number represented by the object at my current cursor position"

	| chosenMorph |
	submorphs isEmpty ifTrue: [^ 0].
	chosenMorph _ submorphs at: ((cursor truncated max: 1) min: submorphs size).
	^ chosenMorph getNumericValue
