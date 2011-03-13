ReadWriteStream
	subclass: #CompressedSourceStream
	instanceVariableNames: 'segmentFile segmentSize nSegments segmentTable segmentIndex dirty endOfFile'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Files-System'