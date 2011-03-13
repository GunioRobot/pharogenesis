string 
	| string |
	file openReadOnly.
	file position: position.
	string _ file nextChunk.
	file close.
	^ string