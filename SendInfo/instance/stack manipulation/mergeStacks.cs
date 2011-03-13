mergeStacks
	| otherStack |
	otherStack _ savedStacks at: pc.
	savedStacks removeKey: pc.
	stack isEmpty ifTrue: [
		"This happens at the end of a block, or a short circuit conditional.  
		In these cases, it is not possible for execution to 'fall through' to 
		the merge point.  In other words, this is not a real merge point at all, 
		and we just continue execution with the saved stack."
		^ stack _ otherStack ]. 
	"self assert: [stack size = otherStack size].  This assertion was true for every
	method in every subclass of Object, so I think that we can safely omit it!"
	1 to: stack size
		do: [:i | ((stack at: i) ~~ #self
					and: [(otherStack at: i) == #self])
				ifTrue: [stack at: i put: #self]]