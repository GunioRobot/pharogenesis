initialize
	"Set up a Random number generator to be used by atRandom when the 
	user does not feel like creating his own Random generator."

	RandomForPicking _ Random new.
	MutexForPicking _ Semaphore forMutualExclusion