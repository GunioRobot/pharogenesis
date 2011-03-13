transmitQueueNext

	| bufTuple |

	bufTuple _ outputQueue next.
	bytesInOutputQueue _ bytesInOutputQueue - bufTuple second max: 0.
	[
		self 
			sendDataCautiously: bufTuple first 
			bytesToSend: bufTuple second.
	]
		on: Error
		do: [ :ex |
			transmissionError _ true.
		].
	^transmissionError not

