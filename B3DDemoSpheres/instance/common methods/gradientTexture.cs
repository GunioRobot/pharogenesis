gradientTexture
    | txt fill bc |

	fill _ GradientFillStyle ramp: {
		0.0 -> (Color r: 0.05 g: 0.5 b: 1.0). 
		0.5 -> (Color r: 0.70 g: 0.85 b: 1.0). 
		1.0 -> (Color r: 0.05 g: 0.5 b: 1.0)}.
	fill origin: (50@0).
    
	fill direction: 100@0.
	fill radial: false.
    bc := BalloonCanvas extent: (200 @200) depth: 32.
    bc fillRectangle: (0@0 extent: 200 @ 200)
         fillStyle: fill.

  txt := bc form asTexture.
  txt wrap: true.
  txt interpolate: false.
  txt envMode: 1.
  ^txt