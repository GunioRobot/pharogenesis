initialize
	self setupRandom.
	semaphoreForGenerator _ Semaphore forMutualExclusion.
	