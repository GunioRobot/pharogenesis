newWithoutLabel
	"Answer an instance of me without a label"

	| inst |
	inst _ self basicNew.
	inst setProperty: #suppressLabel toValue: true.
	inst initialize.
	^ inst