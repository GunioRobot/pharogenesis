addLast: value
	"Add value as the last element of the receiver."
	lastIndex _ nil.  "flush access cache"
	(runs size=0 or: [values last ~= value])
	  ifTrue:
		[runs addLast: 1.
		values addLast: value]
	  ifFalse:
		[runs at: runs size put: runs last+1]