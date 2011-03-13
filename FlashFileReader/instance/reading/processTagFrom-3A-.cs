processTagFrom: aStream
	"Read and process the next tag from the input stream."
	| tag data result |
	tag := aStream nextTag.
	log ifNotNil:[
		log cr; nextPutAll:'Tag #'; print: tag key.
		log nextPutAll:' ('; nextPutAll: (TagTable at: tag key + 1); space; print: tag value size;
			nextPutAll:' bytes)'.
		self flushLog].
	data := FlashFileStream on: (ReadStream on: tag value).
	result := self dispatch: data on: tag key+1 in: TagTable ifNone:[self processUnknown: data].
	(log isNil or:[data atEnd]) ifFalse:[
		log 
			nextPutAll:'*** ';
			print: (data size - data position);
			nextPutAll:' bytes skipped ***'.
		self flushLog].
	^result