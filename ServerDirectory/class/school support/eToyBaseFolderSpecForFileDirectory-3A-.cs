eToyBaseFolderSpecForFileDirectory: aFileDirectory
	^self localEToyBaseFolderSpecs at: aFileDirectory ifAbsent:[nil]