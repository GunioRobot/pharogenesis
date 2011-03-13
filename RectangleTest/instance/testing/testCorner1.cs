testCorner1
   "RectangleTest new testCorner1"
    | rect |
   rect := 10@10 extent: 20@30.
   self deny: (rect containsPoint: rect corner).