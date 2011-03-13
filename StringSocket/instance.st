ObjectSocket
	subclass: #StringSocket
	instanceVariableNames:
		'numStringsInNextArray stringsForNextArray nextStringSize files startTime stringCounter socketWriterProcess outputQueue bytesInOutputQueue extraUnsentBytes transmissionError '
	classVariableNames: 'MaxRatesSeen RecentSendHistory RunningSendCount '
	poolDictionaries: ''
	category: 'Network-ObjectSocket'