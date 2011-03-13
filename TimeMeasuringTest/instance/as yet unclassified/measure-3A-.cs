measure: measuredBlock 
	shouldProfile 
		ifTrue: [TimeProfileBrowser onBlock: [10 timesRepeat: measuredBlock]].
	realTime := measuredBlock timeToRun