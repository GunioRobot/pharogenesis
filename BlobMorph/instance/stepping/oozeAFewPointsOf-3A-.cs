oozeAFewPointsOf: verts
	" change some points at random to cause oozing across screen "
	| n v |

	(verts size sqrt max: 2) floor timesRepeat: [
		n := (verts size * random next) floor + 1.
		v := verts at: n.
		v := (v x + (random next * 2.0 - 1.0))  @ 
			(v y + (random next * 2.0 - 1.0)).
		verts at: n put: v + velocity ].

