from3DS: aDictionary
	"Initialize the receiver from a 3DS point light"
	| color |
	position _ aDictionary at: #position.
	color _ aDictionary at: #color.
	lightColor _ B3DMaterialColor color: color.
	attenuation _ B3DLightAttenuation constant: 1.0 linear: 0.0 squared: 0.0.