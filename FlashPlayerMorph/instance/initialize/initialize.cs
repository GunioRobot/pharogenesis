initialize
	super initialize.
	color _ Color white.
	self loopFrames: true.
	localBounds _ bounds.
	activationKeys _ #().
	activeMorphs _ SortedCollection new: 50.
	activeMorphs sortBlock:[:m1 :m2| m1 depth > m2 depth].
	progressValue _ ValueHolder new.
	progressValue contents: 0.0.
	self defaultAALevel: 2.
	self deferred: true.