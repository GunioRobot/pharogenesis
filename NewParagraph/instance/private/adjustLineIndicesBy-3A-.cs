adjustLineIndicesBy: delta
	firstCharacterIndex _ firstCharacterIndex + delta.
	lines do: [:line | line slide: delta].
