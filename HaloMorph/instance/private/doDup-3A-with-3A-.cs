doDup: evt with: dupHandle
	"Ask hand to duplicate my target."

	evt hand setArgument: target.
	self setTarget: evt hand duplicateMorph.
	self removeAllHandlesBut: dupHandle