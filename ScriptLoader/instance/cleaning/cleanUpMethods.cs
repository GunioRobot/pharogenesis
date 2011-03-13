cleanUpMethods
	"Make sure that all methods in use are restarted"

	WeakArray restartFinalizationProcess.
	MethodChangeRecord allInstancesDo:[:x| x noteNewMethod: nil].
	Delay startTimerInterruptWatcher.
	WorldState allInstancesDo:[:ws| ws convertAlarms; convertStepList].
	ExternalDropHandler initialize.
	ScrollBar initializeImagesCache.
	GradientFillStyle initPixelRampCache.
	ProcessBrowser initialize.
	Smalltalk garbageCollect.

	self assert: (CompiledMethod allInstances
	reject:[:cm| cm hasNewPropertyFormat]) isEmpty.