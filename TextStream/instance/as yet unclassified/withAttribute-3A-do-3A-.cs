withAttribute: att do: strmBlock
	| pos1 val |
	pos1 _ self position.
	val _ strmBlock value.
	collection addAttribute: att from: pos1+1 to: self position.
	^ val