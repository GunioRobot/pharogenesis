wheel: thisMany
	"An array of thisMany colors around the color wheel starting at self and ending all the way around the hue space just before self.  Array is of length thisMany.  Very useful for displaying color based on a variable in your program.  "

	| sat bri hue step c |
	thisMany = 1 ifTrue: [^ Array with: self].
	sat _ self saturation.
	bri _ self brightness.
	hue _ self hue.
	step _ 360.0 / thisMany.
	^ (1 to: thisMany) collect: [:num |
		c _ Color h: hue s: sat v: bri.  "hue is taken mod 360"
		hue _ hue + step.
		c].
