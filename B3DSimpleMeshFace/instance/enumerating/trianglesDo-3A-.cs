trianglesDo: aBlock
	"Evaluate aBlock with triangular faces"
	| face |
	self size = 3
		ifTrue:[^aBlock value: self].
	3 to: self size do:[:i|
		face _ self class with: (self at: 1) with: (self at: i-1) with: (self at: i).
		aBlock value: face].