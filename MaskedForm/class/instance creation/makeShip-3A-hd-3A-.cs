makeShip: aScale hd: aHeading
	"Make a 'ship' (arrowhead-shaped) facing in the heading given by aHeading.   Use s as scale factor.
	 By Alan Kay 2/96.  Simplified and reformatted by 5/30/96 sw"

	| sampleForm scaled aPen m n r loc  box | 

	scaled _ (80 * aScale) asInteger.
	sampleForm _ Form extent: (scaled@scaled).  "Make a form"
	aPen _ Pen newOnForm: sampleForm. 

"make a ship shape"
	loc _ 40@40. 		
	m _ 8. n _ 20. r _ 54.
	aPen place: loc. aPen north.
		box _ loc corner: loc.
	aPen turn: aHeading +180; up.
	aPen go: m * aScale; down; turn: 45.
		box _ box encompass: aPen location.
	aPen go: n * aScale.
		box _ box encompass: aPen location.
	aPen turn: 150; go: r * aScale.
		box _ box encompass: aPen location.
	aPen place: loc. aPen north.
	aPen turn: aHeading + 180; up.
	aPen go: m * aScale; down; turn: -45.
		box _ box encompass: aPen location.
	aPen go: n* aScale.
		box _ box encompass: aPen location.
	aPen turn: -150; go: r * aScale.
		box _ box encompass: aPen location.

	^ Cursor wait showWhile:		"Transparent around the outside"
		[self from: sampleForm box: ((box truncated) expandBy: 2)].

"Try it.
	(MaskedForm makeShip: 1 hd: 0) followCursor
"


