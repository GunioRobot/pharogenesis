copy: mthFinder addArg: aConstant
	| more |
	"Copy inputs and answers, add an additional data argument to the inputs.  The same constant for every example"

	more _ Array with: aConstant.
	data _ mthFinder data collect: [:argList | argList, more].
	answers _ mthFinder answers.
	self load: nil.
