colorTilesWith: firstColor and: lastColor 

  | form txt nroPu ps pt |

  nroPu := 12.

  form := Form extent: (nroPu@ nroPu*16) depth: 32.
   ps := 0 .
   0 to: nroPu//2 do:
   [:j |
   pt := 0 @ ps.
   0 to: nroPu//2 do:
    [:idx |
      form fill: (0 @ 0 + pt extent: 16@16) fillColor: firstColor;
            fill: (16 @16 + pt extent: 16 @ 16) fillColor: firstColor;
            fill: (0 @ 16 + pt extent: 16 @ 16) fillColor: lastColor;
            fill: (16 @ 0 + pt extent: 16 @ 16) fillColor: lastColor.
      pt := (32 @ 0) + pt
     ].
    ps := 32 + ps
   ].
  txt := form asTexture.
  txt wrap: true.
  txt interpolate: false.
  txt envMode: 0.
  ^txt