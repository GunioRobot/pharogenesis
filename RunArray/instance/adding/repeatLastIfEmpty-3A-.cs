repeatLastIfEmpty: defaultBlock
	"add the last value back again.  If we are empty, add (defaultBlock value)"
	lastIndex _ nil.  "flush access cache"
	(runs size=0)
	  ifTrue:[
		 runs addLast: 1.
		values addLast: defaultBlock value]
	  ifFalse:
		[runs at: runs size put: runs last+1]