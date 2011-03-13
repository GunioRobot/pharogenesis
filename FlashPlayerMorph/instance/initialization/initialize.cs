initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	self loopFrames: true.
	localBounds := bounds.
	activationKeys := #().
	activeMorphs := SortedCollection new: 50.
	activeMorphs
		sortBlock: [:m1 :m2 | m1 depth > m2 depth].
	progressValue := ValueHolder new.
	progressValue contents: 0.0.
	self defaultAALevel: 2.
	self deferred: true