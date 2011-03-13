recordStartSound: id info: info
	| theSound |
	theSound := self createSound: id info: info.
	theSound ifNotNil:[player addSound: theSound at: frame].