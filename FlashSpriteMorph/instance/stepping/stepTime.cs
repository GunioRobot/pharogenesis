stepTime
	"If we're syncing with time step at double speed."
	^self useTimeSync
		ifTrue:[stepTime // 2]
		ifFalse:[stepTime]