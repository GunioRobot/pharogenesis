primitiveSoundRecordSamplesInto: buf startingAt: startWordIndex 
	"Record a buffer's worth of 16-bit sound samples."
	| bufSizeInBytes samplesRecorded |
	self primitive: 'primitiveSoundRecordSamples'
		parameters: #(WordArray SmallInteger ).

	interpreterProxy failed
		ifFalse: [bufSizeInBytes _ (interpreterProxy slotSizeOf: buf cPtrAsOop) * 4.
			interpreterProxy success: (startWordIndex >= 1 and: [startWordIndex - 1 * 2 < bufSizeInBytes])].

	interpreterProxy failed ifFalse: [samplesRecorded _ self cCode: 'snd_RecordSamplesIntoAtLength((int)buf, startWordIndex - 1, bufSizeInBytes)'].
	^ samplesRecorded asPositiveIntegerObj