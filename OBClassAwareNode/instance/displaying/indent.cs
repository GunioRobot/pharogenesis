indent
	| size indent |
	size := 0.
	self superiorsDo: [:ea | size := size + 1].
	indent := Text new: size * 2.
	indent atAllPut: $ .
	^ indent