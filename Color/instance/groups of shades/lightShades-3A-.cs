lightShades: thisMany
	"An array of thisMany colors from white to self. Very useful for displaying color based on a variable in your program.  6/18/96 tk"

	^ self class white mix: self shades: thisMany

"| a r |  a _ (Color red lightShades: 10).  
	r _ 0@0 extent: 30@30.
	a do: [:each |
		r moveBy: 30@0.
		Display fill: r fillColor: each].
"