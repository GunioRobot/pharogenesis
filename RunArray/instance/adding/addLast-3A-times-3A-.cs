addLast: value  times: times
	"Add value as the last element of the receiver, the given number of times"
	times = 0 ifTrue: [ ^self ].
	lastIndex _ nil.  "flush access cache"
	(runs size=0 or: [values last ~= value])
	  ifTrue:
		[runs add: times.
		values add: value]
	  ifFalse:
		[runs at: runs size put: runs last+times]