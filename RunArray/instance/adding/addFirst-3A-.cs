addFirst: value
	"Add value as the first element of the receiver."
	lastIndex _ nil.  "flush access cache"
	(runs size=0 or: [values first ~= value])
	  ifTrue:
		[runs addFirst: 1.
		values addFirst: value]
	  ifFalse:
		[runs at: 1 put: runs first+1]