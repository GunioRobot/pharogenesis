isLongJump: offset

	^(self peekByte: offset) >= 160 and: [(self peekByte: offset) < 168]