createDefaultScene
	| camera headLight |
	super createDefaultScene.
	camera _ B3DCamera new.
	camera position: 0@0@-6.
	camera target: 0@0@0.
	camera fov: 15.0.
	scene defaultCamera: camera.
	headLight := B3DSpotLight new.
	headLight position: 0@-1@0.
	headLight target: 0@0@0.
	headLight lightColor: (B3DMaterialColor color: (Color blue)).
	headLight attenuation: (B3DLightAttenuation constant: 1.0 linear: 0.0 squared: 0.0).
	headLight minAngle: 5.
	headLight maxAngle: 6.
	scene lights add: headLight.
	scene objects do: [ :object |
		object material: nil]