createLightsForScene1: aScene


	| ambientLight |

     ambientLight :=B3DAmbientLight new.	
	ambientLight lightColor: (B3DMaterialColor color: Color white).
	
	aScene lights add: ambientLight.