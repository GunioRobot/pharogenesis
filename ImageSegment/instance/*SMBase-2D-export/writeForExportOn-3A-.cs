writeForExportOn: fileStream
	"Write the segment on the disk with all info needed to reconstruct it in a new image.  For export.  Out pointers are encoded as normal objects on the disk."

	| temp |
	state = #activeCopy ifFalse: [self error: 'wrong state'].
	temp _ endMarker.
	endMarker _ nil.
	fileStream fileOutClass: nil andObject: self.
		"remember extra structures.  Note class names."
	endMarker _ temp.
