initialize
	"ProcessBrowser initialize"
	Browsers ifNil: [ Browsers _ WeakSet new ].
	SuspendedProcesses ifNil: [ SuspendedProcesses _ IdentityDictionary new ].
	Smalltalk addToStartUpList: self.
	Smalltalk addToShutDownList: self.
	self registerInFlapsRegistry.