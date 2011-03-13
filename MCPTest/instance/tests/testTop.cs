testTop
	"test the #top: messages and its consequences"

	| morph factor newTop newBounds |
	morph _ Morph new.
	""
	factor _ 10.
	newTop _ self defaultTop + factor.
	newBounds _ self defaultBounds translateBy: 0 @ factor.
	""
	morph top: newTop.
	""
	self assert: morph top = newTop;
		 assert: morph bounds = newBounds