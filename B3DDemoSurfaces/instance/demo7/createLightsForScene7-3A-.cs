createLightsForScene7: aScene

	| light1 light2 light3 light4 |

	light1 := B3DDirectionalLight new.
	light1 direction: 100 @ -20 @ 0.
     light1 lightColor: (B3DMaterialColor color: (Color r: 0.75 g: 0.28 b: 0.28)).
	scene lights add: light1.

	light2 := B3DDirectionalLight new.
	light2 direction: (240 degreesToRadians cos) * 100 @ -20 @ (240 degreesToRadians sin * 100).
     light2 lightColor: (B3DMaterialColor color: (Color r: 0.25 g: 0.8 b: 0.25)).
	scene lights add: light2.

	light3 := B3DDirectionalLight new.
	light3 direction: (120 degreesToRadians cos) * 100 @ -20 @ (120 degreesToRadians sin * 100).
     light3 lightColor: (B3DMaterialColor color: (Color r: 0.25 g: 0.25 b: 0.8)).
	scene lights add: light3.

	light4 := B3DDirectionalLight new.
	light4 direction: 0 @ -100 @ -10.
     light4 lightColor: (B3DMaterialColor color: (Color r: 0.3 g: 0.3 b: 0.02)).
	scene lights add: light4.
