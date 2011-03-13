copyWithPlayerObliterated
	| holdPlayer copy |
	holdPlayer _ player.
	player _ nil.
	copy _ self deepCopy.
	player _ holdPlayer.
	^ copy 