initialize
	logger := TranscriptStream new.
	vmMaker _ VMMaker default.
	vmMaker logger: logger.
	vmMaker addDependent: self.
	allPluginsSelectionsArray _ Array new: self availableModules size withAll: false.
	internalPluginsSelectionsArray _ Array new.
	externalPluginsSelectionsArray _ Array new.