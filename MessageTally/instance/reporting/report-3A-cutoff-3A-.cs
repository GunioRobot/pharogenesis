report: strm cutoff: threshold 
	tally = 0
		ifTrue: [strm nextPutAll: ' - no tallies obtained']
		ifFalse: 
			[strm nextPutAll: ' - '; print: tally; nextPutAll: ' tallies.'; cr; cr.
			self fullPrintOn: strm tallyExact: false orThreshold: threshold]