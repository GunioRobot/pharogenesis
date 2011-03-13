mix: color2 shades: thisMany
	"Return an array of thisMany colors from self to color2. Very useful for displaying color based on a variable in your program.  6/18/96 tk"

	| redInc greenInc blueInc rr gg bb c out |
	thisMany = 1 ifTrue: [^ Array with: color2].
	redInc _ color2 red - self red / (thisMany-1).
	greenInc _ color2 green - self green / (thisMany-1).
	blueInc _ color2 blue - self blue / (thisMany-1).
	rr _ self red.  gg _ self green.  bb _ self blue.
	out _ (1 to: thisMany) collect: [:num |
		c _ Color r: rr g: gg b: bb.
		rr _ rr + redInc.
		gg _ gg + greenInc.
		bb _ bb + blueInc.
		c].
	out at: out size put: color2.	"hide roundoff errors"
	^ out

"| a r |  a _ (Color red mix: Color green shades: 10).  
	r _ 0@0 extent: 30@30.
	a do: [:each |
		r moveBy: 30@0.
		Display fill: r fillColor: each].
"