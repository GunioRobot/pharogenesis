preGCAction: fullGCFlag

	self compilerPreGCHook: fullGCFlag.
	activeContext == nilObj ifFalse: [self storeContextRegisters: activeContext].