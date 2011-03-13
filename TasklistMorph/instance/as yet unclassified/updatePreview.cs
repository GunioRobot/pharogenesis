updatePreview
	"Update the preview.."
	
	self preview removeAllMorphs.
	self activeTask ifNotNilDo: [:t |
		self preview addMorphCentered: (t morph taskThumbnailOfSize: self preview extent)]