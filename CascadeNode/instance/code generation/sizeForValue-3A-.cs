sizeForValue: encoder

	| size |
	size := (receiver sizeForValue: encoder) + (messages size - 1 * 2).
	messages do: [:aMessage | size := size + (aMessage sizeForValue: encoder)].
	^size