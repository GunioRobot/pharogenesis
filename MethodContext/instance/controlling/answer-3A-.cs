answer: anObject
	"Modify my code, from the current program counter value, to answer anObject."
	| methodSize |
	self push: anObject.
	(method at: pc) = 124 ifFalse: [
		methodSize _ method size.
		method _ (
			(method copyFrom: 1 to: pc + 4)
				at: pc + 1 put: 124;
				at: pc + 2 put: (method at: methodSize - 2);
				at: pc + 3 put: (method at: methodSize - 1);
				at: pc + 4 put: (method at: methodSize);
				yourself)]