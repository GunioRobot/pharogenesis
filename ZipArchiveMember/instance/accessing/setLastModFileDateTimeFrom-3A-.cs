setLastModFileDateTimeFrom: aSmalltalkTime
	| unixTime |
	unixTime _ aSmalltalkTime -  2177424000.		"PST?"
	lastModFileDateTime _ self unixToDosTime: unixTime