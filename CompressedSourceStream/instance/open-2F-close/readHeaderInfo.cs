readHeaderInfo
	| valid a b |
	segmentFile position: 0.
	segmentSize _ segmentFile nextNumber: 4.
	nSegments _ segmentFile nextNumber: 4.
	endOfFile _ segmentFile nextNumber: 4.
	segmentFile size < (nSegments+1 + 3 * 4) ifTrue: "Check for reasonable segment info"
		[self error: 'This file is not in valid compressed source format'].
	segmentTable _ (1 to: nSegments+1) collect: [:x | segmentFile nextNumber: 4].
	segmentTable first ~= self firstSegmentLoc ifTrue:
		[self error: 'This file is not in valid compressed source format'].
	valid _ true.
	1 to: nSegments do:  "Check that segment offsets are ascending"
		[:i | a _ segmentTable at: i.  b _ segmentTable at: i+1.
		(a = 0 and: [b ~= 0]) ifTrue: [valid _ false].
		(a ~= 0 and: [b ~= 0]) ifTrue: [b <= a ifTrue: [valid _ false]]].
	valid ifFalse:
		[self error: 'This file is not in valid compressed source format'].
	dirty _ false.
	self position: 0.