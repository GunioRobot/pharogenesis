tree2
	"Draw a recursive tree whose trunk length determined by my length instance variable. Stop when depth is < 1. This version uses randomness to create a more natural looking, asymmetric tree. It also changes the turtle's hue a little each generation."

	depth < 1 ifTrue: [^ self stop].
	depth _ depth - 1.
	self color: (Color h: self color hue + 10 s: 0.7 v: 0.7).
	self forward: length.
	length _ (0.5 + ((self random: 450) / 1000.0)) * length.
	self turnRight: 10 + (self random: 20).
	self replicate.
	self turnLeft: 30 + (self random: 20).
	self replicate.
	self die.
