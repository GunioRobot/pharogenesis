blockSelectModuleName: moduleNameOrNil

	^ [:mRef | (self extractCallModuleNames: mRef) value = moduleNameOrNil]