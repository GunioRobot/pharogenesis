doDup: evt with: dupHandle
	"Ask hand to duplicate my target."

	evt hand setArgument: target; duplicateMorph.
	target _ evt hand firstSubmorph.
	self removeAllHandlesBut: dupHandle.
