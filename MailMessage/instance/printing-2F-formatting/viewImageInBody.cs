viewImageInBody
	| stream image |
	stream _ self body contentStream.
	image _ Form fromBinaryStream: stream.
	(World drawingClass withForm: image) openInWorld