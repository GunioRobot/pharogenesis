decompressFromByteArray: b
	| s size |
	s _ ReadStream on: b.
	size _ 0.
	1 to: 4 do: [:i | size _ (size * 256) + s next].
	^ (self new: size) readCompressedFrom: s