vmStatisticsReportString
	"StringHolderView open: (StringHolder new contents:
		SmalltalkImage current vmStatisticsReportString) label: 'VM Statistics'"

	| params oldSpaceEnd youngSpaceEnd memoryEnd fullGCs fullGCTime incrGCs incrGCTime tenureCount mcMisses mcHits icHits upTime sendCount tms tmSize upTime2 fullGCs2 fullGCTime2 incrGCs2 incrGCTime2 tenureCount2 str |
	params _ self getVMParameters.
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

	str _ WriteStream on: (String new: 1000).
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
		nextPutAll: (fullGCs + incrGCs) asStringWithCommas.
	fullGCs + incrGCs > 0 ifTrue: [
		str
			nextPutAll: ' ('; 
			print: ((upTime / (fullGCs + incrGCs)) roundTo: 1); 
			nextPutAll: 'ms between GCs)'
	].
	str cr.
	str	nextPutAll: '	full			';
		print: fullGCs; nextPutAll: ' totalling '; nextPutAll: fullGCTime asStringWithCommas; nextPutAll: 'ms (';
		print: ((fullGCTime / upTime * 100) roundTo: 1.0);
		nextPutAll: '% uptime)'.
	fullGCs = 0 ifFalse:
		[str	nextPutAll: ', avg '; print: ((fullGCTime / fullGCs) roundTo: 1.0); nextPutAll: 'ms'].
	str	cr.
	str	nextPutAll: '	incr		';
		print: incrGCs; nextPutAll: ' totalling '; nextPutAll: incrGCTime asStringWithCommas; nextPutAll: 'ms (';
		print: ((incrGCTime / upTime * 100) roundTo: 1.0);
		nextPutAll: '% uptime), avg '; print: ((incrGCTime / incrGCs) roundTo: 1.0); nextPutAll: 'ms'; cr.
	str	nextPutAll: '	tenures		';
		nextPutAll: tenureCount asStringWithCommas.
	tenureCount = 0 ifFalse:
		[str nextPutAll: ' (avg '; print: (incrGCs / tenureCount) asInteger; nextPutAll: ' GCs/tenure)'].
	str	cr.

LastStats ifNil: [LastStats _ Array new: 6]
ifNotNil: [
	upTime2 _ upTime - (LastStats at: 1).
	fullGCs2 _ fullGCs - (LastStats at: 2).
	fullGCTime2 _ fullGCTime - (LastStats at: 3).
	incrGCs2 _ incrGCs - (LastStats at: 4).
	incrGCTime2 _ incrGCTime - (LastStats at: 5).
	tenureCount2 _ tenureCount - (LastStats at: 6).

	str	nextPutAll: self textMarkerForShortReport ;
		nextPutAll: (fullGCs2 + incrGCs2) asStringWithCommas.
	fullGCs2 + incrGCs2 > 0 ifTrue: [
		str
			nextPutAll: ' ('; 
			print: ((upTime2 / (fullGCs2 + incrGCs2)) roundTo: 1); 
			nextPutAll: 'ms between GCs)'.
	].
	str cr.
	str	nextPutAll: '	uptime		'; print: ((upTime2 / 1000.0) roundTo: 0.1); nextPutAll: 's'; cr.
	str	nextPutAll: '	full			';
		print: fullGCs2; nextPutAll: ' totalling '; nextPutAll: fullGCTime2 asStringWithCommas; nextPutAll: 'ms (';
		print: ((fullGCTime2 / upTime2 * 100) roundTo: 1.0);
		nextPutAll: '% uptime)'.
	fullGCs2 = 0 ifFalse:
		[str	nextPutAll: ', avg '; print: ((fullGCTime2 / fullGCs2) roundTo: 1.0); nextPutAll: 'ms'].
	str	cr.
	str	nextPutAll: '	incr		';
		print: incrGCs2; nextPutAll: ' totalling '; nextPutAll: incrGCTime2 asStringWithCommas; nextPutAll: 'ms (';
		print: ((incrGCTime2 / upTime2 * 100) roundTo: 1.0);
		nextPutAll: '% uptime), avg '.
	incrGCs2 > 0 ifTrue: [
		 str print: ((incrGCTime2 / incrGCs2) roundTo: 1.0); nextPutAll: 'ms'
	].
	str cr.
	str	nextPutAll: '	tenures		';
		nextPutAll: tenureCount2 asStringWithCommas.
	tenureCount2 = 0 ifFalse:
		[str nextPutAll: ' (avg '; print: (incrGCs2 / tenureCount2) asInteger; nextPutAll: ' GCs/tenure)'].
	str	cr.
].
	LastStats at: 1 put: upTime.
	LastStats at: 2 put: fullGCs.
	LastStats at: 3 put: fullGCTime.
	LastStats at: 4 put: incrGCs.
	LastStats at: 5 put: incrGCTime.
	LastStats at: 6 put: tenureCount.

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
			print: ((tmSize / memoryEnd * 100) roundTo: 0.1); nextPutAll: '% of available'; cr].

	^ str contents