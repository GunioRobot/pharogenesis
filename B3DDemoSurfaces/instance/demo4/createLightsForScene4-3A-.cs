createLightsForScene4: aScene

   | headLight light3 light4 |

	headLight := B3DSpotLight new.
	headLight position: 10@0@10.
     headLight direction: 1 @ 0 @ 0.
	headLight target: 0@0@0.
	headLight lightColor: (B3DMaterialColor color: (Color white)).
	headLight attenuation: (B3DLightAttenuation constant: 1.0 linear: 1.0 squared: 0.0).
	headLight minAngle: 50.
	headLight maxAngle: 60.
     aScene lights add: headLight.
  

     light3 := B3DSpotLight new.
     light3 position: 10 @ 3.0 @ 0; 
             direction: 1 @ 2 @ 1;
          target: 0 @ 0 @ 0;
             lightColor: (B3DMaterialColor color: Color green).
    light3 minAngle: 10;
            maxAngle: 70.
    light3  attenuation: (B3DLightAttenuation constant: 1.0 linear: 1.0 squared: 0.0).
    aScene lights add: light3. 

     light4 := B3DSpotLight new.
     light4 position: 0.0 @ 4.0 @ 10.0; 
             direction: 10 @ 10 @ 10;
          target: 0 @ 0 @ 0;
             lightColor: (B3DMaterialColor color: Color red).
    light4 minAngle: 50;
            maxAngle: 90.
    light4  attenuation: (B3DLightAttenuation constant: 1.0 linear: 1.0 squared: 0.0).
    aScene lights add: light4.
