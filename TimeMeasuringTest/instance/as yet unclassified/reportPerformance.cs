reportPerformance
	| str |
	str := CrLfFileStream fileNamed: 'performanceReports.txt'.
	str setToEnd;
		nextPutAll: ' test: ', testSelector;
		nextPutAll: ' time: ', realTime asString; 
		nextPutAll: ' version: ', self versionInformation;
		cr; 
		close