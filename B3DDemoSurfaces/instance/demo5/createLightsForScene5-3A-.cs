createLightsForScene5: aScene

   | light |
     light :=B3DAmbientLight new.
	
	light lightColor: (B3DMaterialColor color: (Color yellow)).
	
	scene lights add: light.
