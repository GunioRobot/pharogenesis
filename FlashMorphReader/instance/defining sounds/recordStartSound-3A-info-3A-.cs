recordStartSound: id info: info
	| theSound |
	theSound _ self createSound: id info: info.
	theSound ifNotNil:[player addSound: theSound at: frame].