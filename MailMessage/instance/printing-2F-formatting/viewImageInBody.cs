viewImageInBody
	| stream image |
	stream _ self body contentStream.
	image _ Form fromBinaryStream: stream.
	(SketchMorph withForm: image) openInWorld