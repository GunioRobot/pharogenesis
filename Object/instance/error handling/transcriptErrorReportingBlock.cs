transcriptErrorReportingBlock
	^ [:aString :aReceiver |
		Transcript cr; show: 'Error! ', aString, '  Receiver: ', aReceiver printString]