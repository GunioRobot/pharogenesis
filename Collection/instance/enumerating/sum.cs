sum
	"Return the sum of all my elements."
	| sum |  sum _ 0.
	self do: [:each | sum _ sum + each].  
	^ sum