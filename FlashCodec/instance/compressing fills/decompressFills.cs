decompressFills
	| fills n |
	n := Integer readFrom: stream.
	fills := Array new: n.
	1 to: n do:[:i|
		fills at: i put: self decompressFillStyle.
	].
	stream next = $X ifFalse:[^self error:'Compression problem'].
	^fills