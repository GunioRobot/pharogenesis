clearTranscript
	Transcript
		clear;
		nextPutAll:	'context cache at ' , contextCache printString ,
					', size ' , contextCacheEntries printString ,
					' length ' , self contextCacheSize printString; cr;
		nextPutAll:	'stack cache at ' , stackCache printString ,
					', size ' , stackCacheEntries printString ,
					' length ' , self stackCacheSize printString; cr;
		endEntry.