forConfigurationFile: aFileName
	| config  fileStream vmMaker |

	fileStream _ FileStream oldFileNamed: aFileName.
	config _ fileStream fileInObjectAndCode.
	vmMaker _ self forPlatform: (config at: 5).
	vmMaker loadConfiguration: config.
	^vmMaker