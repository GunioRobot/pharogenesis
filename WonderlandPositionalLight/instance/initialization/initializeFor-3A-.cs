initializeFor: aWonderland
	"Initialize this light"

	super initializeFor: aWonderland.

	attenuation _ B3DLightAttenuation constant: 1.0 linear: 0.0 squared: 0.0.