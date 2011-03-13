ReadStream
	subclass: #InflateStream
	instanceVariableNames: 'state bitBuf bitPos source sourcePos sourceLimit litTable distTable sourceStream '
	classVariableNames: 'BlockProceedBit BlockTypes FixedDistCodes FixedLitCodes MaxBits StateNewBlock StateNoMoreData '
	poolDictionaries: ''
	category: 'System-Compression'