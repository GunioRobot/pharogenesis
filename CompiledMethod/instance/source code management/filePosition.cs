filePosition
	"Answer the file position of this method's source code."
	| pos |
	self last < 252 ifTrue: [^ 0  "no source"].
	pos _ 0.
	self size - 1 to: self size - 3 by: -1 do: [:i | pos _ pos * 256 + (self at: i)].
	^ pos