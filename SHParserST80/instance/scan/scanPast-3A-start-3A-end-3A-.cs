scanPast: rangeType start: startInteger end: endInteger
	"record rangeType for current token from startInteger to endInteger,
	 and scanNext token"

	^self 
		rangeType: rangeType start: startInteger end: endInteger;
		scanNext
	
