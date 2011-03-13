ObjectSocket
	subclass: #StringSocket
	instanceVariableNames:
		'numStringsInNextArray stringsForNextArray nextStringSize files startTime stringCounter socketWriterProcess outputQueue bytesInOutputQueue extraUnsentBytes transmissionError readBuffer'
	classVariableNames: 'MaxRatesSeen RecentSendHistory RunningSendCount'
	poolDictionaries: ''
	category: 'Nebraska-Network-ObjectSocket'