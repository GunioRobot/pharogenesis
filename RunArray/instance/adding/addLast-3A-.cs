addLast: value
	"Add value as the last element of the receiver."
	lastIndex _ nil.  "flush access cache"
	(runs size=0 or: [values last ~= value])
	  ifTrue:
		[runs _ runs copyWith: 1.
		values _ values copyWith: value]
	  ifFalse:
		[runs at: runs size put: runs last+1]