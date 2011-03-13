darkShades: thisMany
	"An array of thisMany colors from black to the receiver.  Array is of length num. Very useful for displaying color based on a variable in your program.  6/18/96 tk"

	^ self class black mix: self shades: thisMany

"| a r |  a _ (Color red darkShades: 10).  
	r _ 0@0 extent: 30@30.
	a do: [:each |
		r moveBy: 30@0.
		Display fill: r fillColor: each].
"