findString: string
	"Fast version of #upToAll: to find a String in a file starting from the beginning.
	Returns the position and also sets the position there.
	If string is not found 0 is returned and position is unchanged."

	| pos buffer count oldPos sz |
	oldPos _ self position.
	self reset.
	sz _ self size.
	pos _ 0.
	buffer _ String new: 2000.
	[ buffer := self nextInto: buffer.
	(count _ buffer findString: string) > 0
		ifTrue: ["Found the string part way into buffer"
			self position: pos.
			self next: count - 1.
			^self position ].
	pos _ ((pos + 2000 - string size) min: sz).
	self position: pos.
	pos = sz] whileFalse.
	"Never found it, and hit end of file"
	self position: oldPos.
	^0