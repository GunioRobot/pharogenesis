createLightsForScene6: aScene

   | light |
     light :=B3DAmbientLight new.
	
	light lightColor: (B3DMaterialColor color: (Color white)).
	
	aScene lights add: light.