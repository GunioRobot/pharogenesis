vmStatisticsReportString
	"StringHolderView open: (StringHolder new contents:
		Utilities vmStatisticsReportString) label: 'VM Statistics'"

	| params oldSpaceEnd youngSpaceEnd memoryEnd fullGCs fullGCTime incrGCs incrGCTime tenureCount mcMisses mcHits icHits upTime sendCount tms tmSize |
	params _ Smalltalk getVMParameters.
	oldSpaceEnd			_ params at: 1.
	youngSpaceEnd		_ params at: 2.
	memoryEnd			_ params at: 3.
	fullGCs				_ params at: 7.
	fullGCTime			_ params at: 8.
	incrGCs				_ params at: 9.
	incrGCTime			_ params at: 10.
	tenureCount			_ params at: 11.
	mcMisses			_ params at: 15.
	mcHits				_ params at: 16.
	icHits				_ params at: 17.
	upTime _ Time millisecondClockValue.
	sendCount _ mcMisses + mcHits + icHits.
	tms _ TranslatedMethod allSubInstances.
	tmSize _ tms inject: 0 into: [:sum :tm | sum + (tm size * 4)].
	^String streamContents: [:str |
		str	nextPutAll: 'uptime			';
			print: (upTime / 1000 / 60 // 60); nextPut: $h;
			print: (upTime / 1000 / 60 \\ 60) asInteger; nextPut: $m;
			print: (upTime / 1000 \\ 60) asInteger; nextPut: $s; cr.
		str	nextPutAll: 'memory			';
			nextPutAll: memoryEnd asStringWithCommas; nextPutAll: ' bytes'; cr.
		str	nextPutAll:	'	old			';
			nextPutAll: oldSpaceEnd asStringWithCommas; nextPutAll: ' bytes (';
			print: ((oldSpaceEnd / memoryEnd * 100) roundTo: 0.1); nextPutAll: '%)'; cr.
		str	nextPutAll: '	young		';
			nextPutAll: (youngSpaceEnd - oldSpaceEnd) asStringWithCommas; nextPutAll: ' bytes (';
			print: ((youngSpaceEnd - oldSpaceEnd / memoryEnd * 100) roundTo: 0.1); nextPutAll: '%)'; cr.
		str	nextPutAll: '	used		';
			nextPutAll: youngSpaceEnd asStringWithCommas; nextPutAll: ' bytes (';
			print: ((youngSpaceEnd / memoryEnd * 100) roundTo: 0.1); nextPutAll: '%)'; cr.
		str	nextPutAll: '	free		';
			nextPutAll: (memoryEnd - youngSpaceEnd) asStringWithCommas; nextPutAll: ' bytes (';
			print: ((memoryEnd - youngSpaceEnd / memoryEnd * 100) roundTo: 0.1); nextPutAll: '%)'; cr.
		str	nextPutAll: 'GCs				';
			nextPutAll: (fullGCs + incrGCs) asStringWithCommas;
			nextPutAll: ' ('; print: ((upTime / (fullGCs + incrGCs)) roundTo: 1); nextPutAll: 'ms between GCs)'; cr.
		str	nextPutAll: '	full			';
			print: fullGCs; nextPutAll: ' in '; nextPutAll: fullGCTime asStringWithCommas; nextPutAll: 'ms (';
			print: ((fullGCTime / upTime * 100) roundTo: 1.0);
			nextPutAll: '% uptime)'.
		fullGCs = 0 ifFalse:
			[str	nextPutAll: ', avg '; print: ((fullGCTime / fullGCs) roundTo: 1.0); nextPutAll: 'ms'].
		str	cr.
		str	nextPutAll: '	incr		';
			print: incrGCs; nextPutAll: ' in '; nextPutAll: incrGCTime asStringWithCommas; nextPutAll: 'ms (';
			print: ((incrGCTime / upTime * 100) roundTo: 1.0);
			nextPutAll: '% uptime), avg '; print: ((incrGCTime / incrGCs) roundTo: 1.0); nextPutAll: 'ms'; cr.
		str	nextPutAll: '	tenures		';
			nextPutAll: tenureCount asStringWithCommas.
		tenureCount = 0 ifFalse:
			[str nextPutAll: ' (avg '; print: (incrGCs / tenureCount) asInteger; nextPutAll: ' GCs/tenure)'].
		str	cr.

		sendCount > 0 ifTrue: [
			str	nextPutAll: 'sends			';
				nextPutAll: sendCount asStringWithCommas; cr.
			str	nextPutAll: '	full			';
				nextPutAll: mcMisses asStringWithCommas;
				nextPutAll: ' ('; print: ((mcMisses / sendCount * 100) roundTo: 0.1); nextPutAll: '%)'; cr.
			str	nextPutAll: '	m-cache	';
				nextPutAll: mcHits asStringWithCommas;
				nextPutAll: ' ('; print: ((mcHits / sendCount * 100) roundTo: 0.1); nextPutAll: '%)'; cr.
			str	nextPutAll: '	i-cache		';
				nextPutAll: icHits asStringWithCommas;
				nextPutAll: ' ('; print: ((icHits / sendCount * 100) roundTo: 0.1); nextPutAll: '%)'; cr].

		icHits > 0 ifTrue: [
			str	nextPutAll: 'methods			';
				nextPutAll: tms size asStringWithCommas; nextPutAll: ' translated'; cr.
			str	nextPutAll: '	size			';
				nextPutAll: tmSize asStringWithCommas; nextPutAll: ' bytes, avg ';
				print: ((tmSize / tms size) roundTo: 0.1); nextPutAll: ' bytes/method'; cr.
			str	nextPutAll: '	memory		';
				print: ((tmSize / youngSpaceEnd * 100) roundTo: 0.1); nextPutAll: '% of used, ';
				print: ((tmSize / memoryEnd * 100) roundTo: 0.1); nextPutAll: '% of available'; cr]].
