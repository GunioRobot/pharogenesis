position: newPosition
	| compressedBuffer newSegmentIndex |
	newPosition > endOfFile ifTrue:
		[self error: 'Attempt to position beyond the end of file'].
	newSegmentIndex _ (newPosition // segmentSize) + 1.
	newSegmentIndex ~= segmentIndex ifTrue:
		[self flush.
		segmentIndex _ newSegmentIndex.
		newSegmentIndex > nSegments ifTrue:
			[self error: 'file size limit exceeded'].
		segmentFile position: (segmentTable at: segmentIndex).
		(segmentTable at: segmentIndex+1) = 0
			ifTrue:
			[newPosition ~= endOfFile ifTrue:
				[self error: 'Internal logic error'].
			collection size = segmentSize ifFalse:
				[self error: 'Internal logic error'].
			"just leave garbage beyond end of file"]
			ifFalse:
			[compressedBuffer _ segmentFile next: ((segmentTable at: segmentIndex+1) - (segmentTable at: segmentIndex)).
			collection _  (GZipReadStream on: compressedBuffer) upToEnd asString].
		readLimit _ collection size min: endOfFile - self segmentOffset].
	position _ newPosition \\ segmentSize.
	