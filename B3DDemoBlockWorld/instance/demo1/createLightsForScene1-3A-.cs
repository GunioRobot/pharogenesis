createLightsForScene1: aScene

	| ambientLight |

     ambientLight :=B3DAmbientLight new.	
	ambientLight lightColor: (B3DMaterialColor color: Color green).
	
	scene lights add: ambientLight.