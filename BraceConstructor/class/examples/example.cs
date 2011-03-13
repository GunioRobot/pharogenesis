example
	"Test the {a. b. c} syntax.  For more examples, see SequenceableCollection-casing
	 and Dictionary-casing."

	| a b c d e x y |
	x _ {1. {2. 3}. 4}.
	{a. {b. c}. d. e} _ x, {5}, {}.
	y _ {a} _ {0}.
	{} _ {}.
	^{e. d. c. b. a + 1. y first} as: Set

"BraceNode example"
"Smalltalk garbageCollect.
 Time millisecondsToRun: [20 timesRepeat: [BraceNode example]] 1097 2452"