max
	"Return the max of all my elements."
	| max | max _ nil.
	self do: [:each | (max == nil or: [each > max])
					ifTrue: [max _ each]].  
	^ max