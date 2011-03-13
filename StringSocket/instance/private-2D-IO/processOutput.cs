processOutput

	| arrayToWrite size bytesSent timeStartSending t itemsSent now timeSlot bucketAgeInMS bytesThisSlot |

	outBufIndex _ 1.
	itemsSent _ bytesSent _ 0.
	timeStartSending _ Time millisecondClockValue.
	[outObjects isEmpty not and: [self isConnected]] whileTrue: [
		arrayToWrite _ outObjects removeFirst.
		size _ self addToOutBuf: arrayToWrite.
		bytesSent _ bytesSent + size.
		itemsSent _ itemsSent + 1.
		outBufIndex > 10000 ifTrue: [self queueOutBufContents].
	].
	outBufIndex > 1 ifTrue: [self queueOutBufContents].
	bytesSent > 0 ifTrue: [
		MaxRatesSeen ifNil: [MaxRatesSeen _ Dictionary new].
		now _ Time millisecondClockValue.
		t _ now - timeStartSending.
		timeSlot _ now // 10000.	"ten second buckets"
		bucketAgeInMS _ now \\ 10.
		bytesThisSlot _ (MaxRatesSeen at: timeSlot ifAbsent: [0]) + bytesSent.
		MaxRatesSeen 
			at: timeSlot 
			put: bytesThisSlot.
		NebraskaDebug 
			at: #SendReceiveStats 
			add: {'put'. bytesSent. t. itemsSent. bytesThisSlot // (bucketAgeInMS max: 100)}.
	].
