traceProblem: aString from: aContext
	RecursionLock == true ifTrue:[^self].
	RecursionLock _ true.
	Transcript cr; show: aString; cr; show: aContext shortStack.
	RecursionLock _ false.