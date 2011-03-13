sourcePointer
	"Answer the integer which can be used to find the source file and position for this method.
	The returned value is either 0 (if no source is stored) or a number between 16r1000000 and 16r4FFFFFF.
	The actual interpretation of this number is up to the SourceFileArray stored in the global variable SourceFiles."

	| pos |
	self last < 252 ifTrue: [^ 0  "no source"].
	pos := self last - 251.
	self size - 1 to: self size - 3 by: -1 do: [:i | pos := pos * 256 + (self at: i)].
	^pos