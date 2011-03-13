doAgainOnce: characterStream 
	"Do the previous thing again once. 1/26/96 sw"

	self closeTypeIn: characterStream.
	self again.
	^ true