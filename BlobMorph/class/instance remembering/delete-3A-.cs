delete: anInstance
	AllBlobs ifNotNil: [AllBlobs remove: anInstance ifAbsent: []]