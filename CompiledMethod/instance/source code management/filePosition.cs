filePosition
	"Answer the file position of this method's source code."
	| end |
	end _ self size.
	^ ((self at: end) bitAnd: 63) * 256 + (self at: end - 1) * 256 + (self at: end - 2)