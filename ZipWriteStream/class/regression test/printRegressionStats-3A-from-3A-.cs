printRegressionStats: stats from: fd
	| raw compressed numFiles |
	raw _ stats at: #rawSize ifAbsent:[0].
	raw = 0 ifTrue:[^self].
	compressed _ stats at: #compressedSize ifAbsent:[0].
	numFiles _ stats at: #numFiles ifAbsent:[0].
	Transcript cr; nextPutAll: fd pathName.
	Transcript crtab; nextPutAll:'Files compressed: ', numFiles asStringWithCommas.
	Transcript crtab; nextPutAll:'Bytes compressed: ', raw asStringWithCommas.
	Transcript crtab; nextPutAll:'Avg. compression ratio: ';
		print: ((compressed / raw asFloat * 100.0) truncateTo: 0.01).
	Transcript endEntry.