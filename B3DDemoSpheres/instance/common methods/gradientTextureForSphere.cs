gradientTextureForSphere
    | txt fill bc |

    fill _ GradientFillStyle ramp: {
        0.0 -> (Color r: 0.85 g: 0.85 b: 0.75).
        1.0 -> (Color r: 0.85 g: 0.5 b: 0.05)}.
    fill origin: (200@200).
    
    fill direction: 140@140.
    fill radial: true.
    bc := BalloonCanvas extent: (400 @ 400) depth: 32.
    bc fillRectangle: (0@0 extent: 400 @ 400)
        fillStyle: fill.

  txt := bc form asTexture.
  txt wrap: true.
  txt interpolate: false.
  txt envMode: 1.
  ^txt