storeDataOn: aDataStream
	"Contexts are not allowed go to out in DataStreams.  They must be included inside an ImageSegment."

	self error: 'This Context was not included in the ImageSegment'.
		"or perhaps ImageSegments were not used at all"
	^ nil