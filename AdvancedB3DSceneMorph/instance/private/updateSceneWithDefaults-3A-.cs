updateSceneWithDefaults: myScene
	| headLight mat |
	myScene lights at: 'Ambient1' put: (B3DAmbientLight color: (Color gray: 0.2)).
	headLight := B3DSpotLight new.
	headLight position: myScene defaultCamera position.
	headLight target: myScene defaultCamera target.
	headLight lightColor: (B3DMaterialColor color: (Color gray: 0.7)).
	headLight attenuation: (B3DLightAttenuation constant: 1.0 linear: 0.0 squared: 0.0).
	headLight minAngle: 80.
	headLight maxAngle: 90.
	myScene lights at: '$HeadLight$' put: headLight copy.
	mat := B3DMaterial new.
	mat diffusePart: (Color gray: 0.25).
	mat ambientPart: (Color gray: 0.01).
	myScene objects do: [:o|
		o material: mat].
	^myScene