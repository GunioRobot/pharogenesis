hex
    | result stream |
	result := String new: self size * 2.
	stream := result writeStream.
	1 to: self size do: [ :ix | |each|
		each := self at: ix.
		stream
			nextPut: ('0123456789ABCDEF' at: each // 16 + 1);
			nextPut: ('0123456789ABCDEF' at: each \\ 16 + 1)].
    ^ result