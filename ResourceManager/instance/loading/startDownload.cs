startDownload
	"Start downloading unloaded resources"
	self stopDownload.
	unloaded isEmpty ifTrue:[^self].
	self loadCachedResources.
	unloaded isEmpty ifTrue:[^self].
	stopFlag _ false.
	stopSemaphore _ Semaphore new.
	loaderProcess _ [self loaderProcess] newProcess.
	loaderProcess priority: Processor lowIOPriority.
	loaderProcess resume.