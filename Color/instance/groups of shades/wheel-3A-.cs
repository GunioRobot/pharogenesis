wheel: thisMany
	"An array of thisMany colors around the color wheel starting at self and ending all the way around the hue space just before self.  Array is of length thisMany.  Very useful for displaying color based on a variable in your program.  6/18/96 tk"

	| sat bri hue step c |
	thisMany = 1 ifTrue: [^ Array with: self].
	sat _ self saturation.
	bri _ self brightness.
	hue _ self hue.
	step _ 360.0/thisMany.
	^ (1 to: thisMany) collect: [:num |
		c _ Color hue: hue saturation: sat brightness: bri.
		hue _ hue + step.	"it does mod 360"
		c].


"| a r |  a _ (Color blue wheel: 20).  
	r _ 0@0 extent: 30@30.
	a do: [:each |
		r moveBy: 30@0.
		Display fill: r fillColor: each].
"