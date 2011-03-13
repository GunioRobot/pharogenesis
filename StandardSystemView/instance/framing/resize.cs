resize
	"Determine the rectangular area for the receiver, adjusted to the 
	minimum and maximum sizes."
	| f |
	f _ self getFrame.
	self resizeTo: (f topLeft + (0@ labelFrame height) extent: f extent)
