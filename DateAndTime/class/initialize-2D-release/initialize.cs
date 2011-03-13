initialize

	super initialize.

	ClockProvider := Time.
	LastTickSemaphore := Semaphore forMutualExclusion.
	LastMilliSeconds := 0.
	LocalOffset := nil.
	LastTick := 0.
	Smalltalk addToStartUpList: self.
	self startUp: true.