eToyUserListUrlForFileDirectory: aFileDirectory
	^self localEToyUserListUrls at: aFileDirectory ifAbsent:[nil]