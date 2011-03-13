answer: anObject
	"Modify my code, from the current program counter value, to answer anObject."

	self push: anObject.
	(method at: pc) = 124 ifFalse: [
		method _ (
			(method clone)
				at: pc + 1 put: 124;
				yourself)]