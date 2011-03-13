backwards
	"Answer the characters of the receiver in reversed order.  1/18/96 sw"
	| aStream |
	aStream _ ReadWriteStream on: ''.
	self size to: 1 by: -1 do:
		[:i | aStream nextPut: (self at: i)].
	^ aStream contents

"'frog' backwards"