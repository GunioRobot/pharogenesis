createLightsForScene4: aScene

	| light1 light2 light3 |

	light1 := B3DDirectionalLight new.
	light1 direction: 100 @ 0 @ 0.
     light1 lightColor: (B3DMaterialColor color: (Color r: 0.8 g: 0.15 b: 0.15)).
	scene lights add: light1.

	light2 := B3DDirectionalLight new.
	light2 direction: (120 degreesToRadians cos) * 100  @ (120 degreesToRadians sin * 100) @ 0.
     light2 lightColor: (B3DMaterialColor color: (Color r: 0.15 g: 0.8 b: 0.15)).
	scene lights add: light2.

	light3 := B3DDirectionalLight new.
	light3 direction: (240 degreesToRadians cos) * 100  @ (240 degreesToRadians sin * 100) @ 0.
     light3 lightColor: (B3DMaterialColor color: (Color r: 0.15 g: 0.15 b: 0.8)).
	scene lights add: light3.

