loaderProcess
	| loader requests req locator resource stream |
	loader _ HTTPLoader default.
	requests _ Dictionary new.
	self prioritizedUnloadedResources do:[:loc|
		req _ HTTPLoader httpRequestClass for: (self hackURL: loc urlString) in: loader.
		loader addRequest: req.
		requests at: req put: loc].
	[stopFlag or:[requests isEmpty]] whileFalse:[
		stopSemaphore waitTimeoutMSecs: 500.
		requests keys "need a copy" do:[:r|
			r isSemaphoreSignaled ifTrue:[
				locator _ requests at: r.
				requests removeKey: r.
				stream _ r contentStream.
				resource _ resourceMap at: locator ifAbsent:[nil].
				self class cacheResource: locator urlString stream: stream.
				self installResource: resource
					from: stream
					locator: locator.
				(resource isForm) ifTrue:[
					WorldState addDeferredUIMessage: self formChangedReminder]
ifFalse: [self halt].
			].
		].
	].
	"Either done downloading or terminating process"
	stopFlag ifTrue:[loader abort].
	loaderProcess _ nil.
	stopSemaphore _ nil.