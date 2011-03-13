setSourcePointer: srcPointer

	self setMySourcePointer: srcPointer.
	self embeddedBlockMethods do: [:m |
		m setSourcePointer: srcPointer].
