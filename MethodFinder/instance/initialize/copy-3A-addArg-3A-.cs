copy: mthFinder addArg: aConstant
	| more |
	"Copy inputs and answers, add an additional data argument to the inputs.  The same constant for every example"

	more := Array with: aConstant.
	data := mthFinder data collect: [:argList | argList, more].
	answers := mthFinder answers.
	self load: nil.
