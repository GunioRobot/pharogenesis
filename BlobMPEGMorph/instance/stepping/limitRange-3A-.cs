limitRange: verts
	" limit radius to range 20-120; limit interpoint angle to surrounding angles with max of twice of average separation. "
	| cent new prevn nextn prevDeg nextDeg thisDeg dincr |

	cent := self bounds center.
	new := Array new: verts size.
	dincr := 360 // verts size.
	verts doWithIndex: [ :pt :n |

		"Find prev/next points, allowing for wrapping around "
		prevn := n-1 < 1 ifTrue: [new size] ifFalse: [n-1].
		nextn := n+1 > new size ifTrue: [1] ifFalse: [n+1].

		"Get prev/this/next point's angles "
		prevDeg := ((verts at: prevn)-cent) degrees.
		thisDeg := ((verts at: n)-cent) degrees.
		nextDeg := ((verts at: nextn)-cent) degrees.

		"Adjust if this is where angles wrap from 0 to 360"
		(thisDeg - prevDeg) abs > 180 ifTrue: [ prevDeg := prevDeg - 360 ].
		(thisDeg - nextDeg) abs > 180 ifTrue: [ nextDeg := nextDeg + 360 ].

		"Put adjusted point into new collection"
		new at: n put: cent +
			(self selfPolarPointRadius: ((((pt - cent) r) min: 60) max: 20) "was min: 80"
				degrees: (((thisDeg min: nextDeg-5) max: prevDeg+5) min: dincr*2+prevDeg)) ].
	^ new
