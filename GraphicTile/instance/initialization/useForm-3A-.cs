useForm: aForm
	"Set the receiver to represent the given form"

	| thumbnail |
	self removeAllMorphs.
	literal _ aForm.
	thumbnail _ ThumbnailMorph  new objectToView: self viewSelector: #literal.
	self addMorphBack: thumbnail.
	thumbnail extent: 16 @ 16.