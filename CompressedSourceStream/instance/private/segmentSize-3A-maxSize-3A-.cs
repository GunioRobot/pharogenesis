segmentSize: segSize maxSize: maxSize
	"Note that this method can be called after the initial open, provided that no
	writing has yet taken place.  This is how to override the default segmentation."
	self size = 0 ifFalse: [self error: 'Cannot set parameters after the first write'].
	segmentFile position: 0.
	segmentFile nextNumber: 4 put: (segmentSize _ segSize).
	segmentFile nextNumber: 4 put: (nSegments _ maxSize // segSize + 2).
	segmentFile nextNumber: 4 put: (endOfFile _ 0).
	segmentTable _ Array new: nSegments+1 withAll: 0.
	segmentTable at: 1 put: self firstSegmentLoc.  "Loc of first segment, always."
	segmentTable do: [:i | segmentFile nextNumber: 4 put: i].
	segmentIndex _ 1.
	collection _ String new: segmentSize.
	writeLimit _ segmentSize.
	readLimit _ 0.
	position _ 0.
	endOfFile _ 0.
	self writeSegment.
