testInitializeIsCallOnceWhenClassIsInitialized
	"self run: #testInitializeIsCallOnceWhenClassIsInitialized"

	
	"as the setup run reset and initialize should be in 1"
	self assert: ObjectWithInitialize classVar =1