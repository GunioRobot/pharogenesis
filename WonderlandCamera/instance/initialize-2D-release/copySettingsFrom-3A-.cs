copySettingsFrom: aB3DCamera
	"Copy my settings from the given B3DCamera"
	| transformer |
	transformer _ B3DVertexTransformer new.
	transformer loadIdentity.
	transformer lookFrom: aB3DCamera position to: aB3DCamera target up: aB3DCamera up.
	self setComposite: transformer modelViewMatrix inverseTransformation.
	perspective _ aB3DCamera perspective.