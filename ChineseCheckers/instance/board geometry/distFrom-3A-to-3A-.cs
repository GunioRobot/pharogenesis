distFrom: a to: b
	"The six possible moves are: 1@0, 1@-1, 0@1, 0@-1, -1@0, -1@1."
	| dx dy |
	dx _ b x - a x.
	dy _ b y - a y.
	dx abs >= dy abs
	ifTrue: ["Major change is in x-coord..."
			dx >= 0
			ifTrue: [(dy between: (0-dx) and: 0)
						ifTrue: [^ dx  "no lateral motion"].
					^ dx + ((0-dx) - dy max: dy - 0)  "added lateral dist"]
			ifFalse: ["Reverse sign and rerun same code"
					^ self distFrom: b to: a]]
	ifFalse: ["Transpose and re-run same code"
			^ self distFrom: a transposed to: b transposed]