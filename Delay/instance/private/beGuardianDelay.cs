beGuardianDelay
	"see comment for class method guardianDelay"
	beingWaitedOn _ false.
	resumptionTime _ SmallInteger maxVal.
	delaySemaphore _ Semaphore new