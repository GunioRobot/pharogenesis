initialize
	super initialize.
	self setupRandom.
	semaphoreForGenerator := Semaphore forMutualExclusion.
	