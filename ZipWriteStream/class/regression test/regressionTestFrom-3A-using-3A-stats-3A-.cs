regressionTestFrom: fd using: tempName stats: stats
	| files file fullName |
	files _ fd fileNames asSortedCollection.
	files do:[:fName|
		file _ nil.
		fullName _ fd fullNameFor: fName.
		fullName = tempName ifFalse:[
			file _ StandardFileStream new open: fullName forWrite: false].
		self compressAndDecompress: file using: tempName stats: stats].
	stats at: #numFiles put: (stats at: #numFiles ifAbsent:[0]) + files size.
	files _ nil.
	self printRegressionStats: stats from: fd.
	fd directoryNames asSortedCollection do:[:dName|
		self regressionTestFrom: (fd directoryNamed: dName) using: tempName stats: stats.
	].