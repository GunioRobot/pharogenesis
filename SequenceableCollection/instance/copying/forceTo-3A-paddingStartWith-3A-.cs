forceTo: length paddingStartWith: elem 
	"Force the length of the collection to length, padding  
	the beginning of the result if necessary with elem.  
	Note that this makes a copy."
	| newCollection padLen |
	newCollection _ self species new: length.
	padLen _ length - self size max: 0.
	newCollection
		from: 1
		to: padLen
		put: elem.
	newCollection
		replaceFrom: padLen + 1
		to: padLen + self size
		with: self
		startingAt:  1.
	^ newCollection