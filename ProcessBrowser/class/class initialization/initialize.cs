initialize
	"ProcessBrowser initialize"
	Browsers ifNil: [ Browsers := WeakSet new ].
	SuspendedProcesses ifNil: [ SuspendedProcesses := IdentityDictionary new ].
	Smalltalk addToStartUpList: self.
	Smalltalk addToShutDownList: self.
	self registerInFlapsRegistry.
	self registerWellKnownProcesses