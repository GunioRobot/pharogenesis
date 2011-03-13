mandala: npoints diameter: d
	"Display restoreAfter: [Pen new mandala: 30 diameter: Display height-100]"
	"On a circle of diameter d, place npoints number of points. Draw all 	possible connecting lines between the circumferential points."
	| l points |
	Display fillWhite.
	l _ 3.14 * d / npoints.
	self home; up; turn: -90; go: d // 2; turn: 90; go: 0 - l / 2; down.
	points _ Array new: npoints.
	1 to: npoints do: 
		[:i | 
		points at: i put: location rounded.
		self go: l; turn: 360.0 / npoints].
	npoints // 2
		to: 1
		by: -1
		do: 
			[:i | 
			self color: i.
			1 to: npoints do: 
				[:j | 
				self place: (points at: j).
				self goto: (points at: j + i - 1 \\ npoints + 1)]]
