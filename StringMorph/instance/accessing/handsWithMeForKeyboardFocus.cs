handsWithMeForKeyboardFocus
	| foc |
	"Answer the hands that have me as their keyboard focus"

	hasFocus ifFalse: [^ #()].
	^ self currentWorld hands select:
		[:aHand | (foc _ aHand keyboardFocus) notNil and: [foc owner == self]]