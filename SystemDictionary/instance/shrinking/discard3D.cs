discard3D
	"Smalltalk discard3D"
	"Discard 3D Support."
	self discardWonderland.
	self
		removeKey: #B3DEngineConstants
		ifAbsent: [].
	self
		at: #InterpolatingImageMorph
		ifPresent: [:cls | cls removeFromSystem].
	SystemOrganization removeCategoriesMatching: 'Graphics-FXBlt'.
	SystemOrganization removeCategoriesMatching: 'Graphics-External'.
	SystemOrganization removeCategoriesMatching: 'Balloon3D-*'.
	SystemOrganization removeCategoriesMatching: 'Graphics-Tools-*'.
	Color removeSelector: #asB3DColor.
	Form removeSelector: #asTexture.
	Morph removeSelector: #asTexture.
	Morph removeSelector: #mapPrimitiveVertex:.
	Morph removeSelector: #installAsWonderlandTextureOn:.
	FileList removeSelector: #open3DSFile.
	Point removeSelector: #@.
	self
		at: #BalloonCanvas
		ifPresent: [:cc | cc removeSelector: #render:].
	Stream removeSelector: #asVRMLStream.
	SketchMorph removeSelector: #drawInterpolatedImage:on:.
	SketchMorph removeSelector: #generateInterpolatedForm.
	self
		at: #B3DEnginePlugin
		ifPresent: [:cls | cls
				withAllSubclassesDo: [:each | each removeFromSystem]].
	DataStream initialize