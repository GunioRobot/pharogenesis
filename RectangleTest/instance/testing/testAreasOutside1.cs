testAreasOutside1
   "RectangleTest new testAreasOutside1"
    | frame rects visibleArea  |
    frame := 0@0 extent: 300@300.
    rects := OrderedCollection new: 80.
    0 to: 3 do: [:i |
      0 to: 2 do: [:j |
            rects add: (i@j * 20 extent: 10@10)
    ]  ].
  
   visibleArea := Array with: frame.
   rects do: [:rect |  | remnants |
      remnants := OrderedCollection new.
      visibleArea do: [:a | remnants addAll: (a areasOutside: rect)].
      visibleArea := remnants.
  ].
  visibleArea := visibleArea asArray.
  self assert: (visibleArea allSatisfy: [:r | r area ~= 0]).

   1 to: visibleArea size do: [:idx |
     idx + 1 to: visibleArea size do: [:idx2 |
        self deny: ((visibleArea at: idx) intersects: (visibleArea at: idx2)).
  ]  ].

  1 to: rects size do: [:idx |
     1 to: visibleArea size do: [:idx2 |
        self deny: ((rects at: idx) intersects: (visibleArea at: idx2)).
  ]  ].

