stepTime
	"If we're syncing with time step at double speed."
	^UseTimeSync
		ifTrue:[stepTime // 2]
		ifFalse:[stepTime]