eToyUserListForFileDirectory: aFileDirectory
	| urlString |
	urlString _ self eToyUserListUrlForFileDirectory: aFileDirectory.
	urlString ifNil:[^nil].
	^self parseEToyUserListFrom: urlString