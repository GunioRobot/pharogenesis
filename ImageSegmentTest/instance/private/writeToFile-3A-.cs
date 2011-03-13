writeToFile: aSegment
	| stream |
	stream := FileStream forceNewFileNamed: self fileName.
	[ aSegment writeForExportOn: stream ]
		ensure: [ stream close ].