repeatLast: times  ifEmpty: defaultBlock
	"add the last value back again, the given number of times.  If we are empty, add (defaultBlock value)"
	times = 0 ifTrue: [^self ].
	lastIndex _ nil.  "flush access cache"
	(runs size=0)
	  ifTrue:
		[runs addLast: times.
		values addLast: defaultBlock value]
	  ifFalse:
		[runs at: runs size put: runs last+times] 