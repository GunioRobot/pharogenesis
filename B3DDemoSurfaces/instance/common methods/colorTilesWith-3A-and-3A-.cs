colorTilesWith: firstColor and: lastColor 
  " This method computes a texure with a chess board coloring. The texture has only four color field. It is designed for continuated use. "

  | form txt |

  form := Form extent: (32@ 32) depth: 32.
 
  form fill: (0 @ 0 extent: 16@16) fillColor: firstColor;
        fill: (16@16 extent: 16 @ 16) fillColor: firstColor;
        fill: (0 @ 16 extent: 16 @ 16) fillColor: lastColor;
        fill: (16 @ 0 extent: 16 @ 16) fillColor: lastColor.
  txt := form asTexture.
 
  txt wrap: false.
  txt interpolate: false.
  txt envMode: 0.
  ^txt