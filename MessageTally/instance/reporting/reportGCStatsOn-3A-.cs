reportGCStatsOn: str
	| oldSpaceEnd youngSpaceEnd memoryEnd fullGCs fullGCTime incrGCs incrGCTime tenureCount upTime rootOverflows |
	upTime _ time.
	oldSpaceEnd			_ gcStats at: 1.
	youngSpaceEnd		_ gcStats at: 2.
	memoryEnd			_ gcStats at: 3.
	fullGCs				_ gcStats at: 7.
	fullGCTime			_ gcStats at: 8.
	incrGCs				_ gcStats at: 9.
	incrGCTime			_ gcStats at: 10.
	tenureCount			_ gcStats at: 11.
	rootOverflows		_ gcStats at: 22.

	str cr.
	str	nextPutAll: '**Memory**'; cr.
	str	nextPutAll:	'	old			';
		nextPutAll: oldSpaceEnd asStringWithCommasSigned; nextPutAll: ' bytes'; cr.
	str	nextPutAll: '	young		';
		nextPutAll: (youngSpaceEnd - oldSpaceEnd) asStringWithCommasSigned; nextPutAll: ' bytes'; cr.
	str	nextPutAll: '	used		';
		nextPutAll: youngSpaceEnd asStringWithCommasSigned; nextPutAll: ' bytes'; cr.
	str	nextPutAll: '	free		';
		nextPutAll: (memoryEnd - youngSpaceEnd) asStringWithCommasSigned; nextPutAll: ' bytes'; cr.

	str cr.
	str	nextPutAll: '**GCs**'; cr.
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
		nextPutAll: '% uptime)'.
	incrGCs = 0 ifFalse:
		[str nextPutAll:', avg '; print: ((incrGCTime / incrGCs) roundTo: 1.0); nextPutAll: 'ms'].
	str cr.
	str	nextPutAll: '	tenures		';
		nextPutAll: tenureCount asStringWithCommas.
	tenureCount = 0 ifFalse:
		[str nextPutAll: ' (avg '; print: (incrGCs / tenureCount) asInteger; nextPutAll: ' GCs/tenure)'].
	str	cr.
	str	nextPutAll: '	root table	';
		nextPutAll: rootOverflows asStringWithCommas; nextPutAll:' overflows'.
	str cr.
