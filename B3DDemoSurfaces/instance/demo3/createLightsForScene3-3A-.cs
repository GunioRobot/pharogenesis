createLightsForScene3: aScene


	| light1 light2 light3 |
	light1 := B3DDirectionalLight new.
	light1 direction: 100 @ 0 @ 0.
     light1 lightColor: (B3DMaterialColor color: (Color r: 0.8 g: 0.38 b: 0.2)).
	scene lights add: light1.

	light1 := B3DDirectionalLight new.
	light1 direction: -100 @ -50 @ 0.
     light1 lightColor: (B3DMaterialColor color: (Color r: 0.15 g: 0.65 b: 0.45)).
	scene lights add: light1.


	light1 := B3DSpotLight new.
     light1 position: 20 @ 10 @ 0;
             direction: 20 negated @ -10 @ 0;
             target: scene boundingBox center.
     light1 attenuation: (B3DLightAttenuation constant: 1.0 linear: 0.5 squared: 0.2).
     light1 lightColor: (B3DMaterialColor color: (Color r: 0.8 g: 0.15 b: 0.15)).
     light1 minAngle: 30;
             maxAngle: 50.
	aScene lights add: light1.

	light2 := B3DSpotLight new.
     light2 position: (120 degreesToRadians cos) * 20  @ (120 degreesToRadians sin * 20) @ 0;
             direction: (120 degreesToRadians cos) * 20 negated  @ (120 degreesToRadians sin * 20 negated) @ 0;
             target: scene boundingBox center.
     light2 attenuation: (B3DLightAttenuation constant: 1.0 linear: 0.5 squared: 0.0).
     light2 lightColor: (B3DMaterialColor color: (Color r: 0.15 g: 0.8 b: 0.15)).
     light2 minAngle: 30;
             maxAngle: 50.
	aScene lights add: light2.

	light3 := B3DSpotLight new.
     light3 position: (240 degreesToRadians cos) * 20  @ (240 degreesToRadians sin * 20) @ 0;
             direction: (240 degreesToRadians cos) * 20 negated @ (240 degreesToRadians sin * 20 negated) @ 0;
             target: scene boundingBox center.
     light3 attenuation: (B3DLightAttenuation constant: 1.0 linear: 0.5 squared: 0.0).
     light3 lightColor: (B3DMaterialColor color: (Color r: 0.15 g: 0.15 b: 0.8)).
     light3 minAngle: 50;
             maxAngle: 70.
	aScene lights add: light3.