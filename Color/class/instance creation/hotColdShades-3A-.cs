hotColdShades: thisMany
	"An array of thisMany colors showing temperature from blue to red to white hot.  (Later improve this by swinging in hue.)  6/19/96 tk"

| n s1 s2 s3 s4 s5 |
thisMany < 5 ifTrue: [^ self error: 'must be at least 5 shades'].
n _ thisMany // 5.
s1 _ self white mix: self yellow shades: (thisMany - (n*4)).
s2 _ self yellow mix: self red shades: n+1.
s2 _ s2 copyFrom: 2 to: n+1.
s3 _ self red mix: self green darker shades: n+1.
s3 _ s3 copyFrom: 2 to: n+1.
s4 _ self green darker mix: self blue shades: n+1.
s4 _ s4 copyFrom: 2 to: n+1.
s5 _ self blue mix: self black shades: n+1.
s5 _ s5 copyFrom: 2 to: n+1.
^ s1,s2,s3,s4,s5

"| a r |  a _ (Color hotColdShades: 25).  
	r _ 0@0 extent: 30@30.
	a do: [:each |
		r moveBy: 30@0.
		Display fill: r fillColor: each].
"