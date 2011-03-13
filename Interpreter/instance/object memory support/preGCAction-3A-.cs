preGCAction: fullGCFlag

	compilerInitialized
		ifTrue:
			[self compilerPreGC: fullGCFlag]
		ifFalse:
			[self storeContextRegisters: activeContext].