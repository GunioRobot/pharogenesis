delete
	| player |
	player _ self flashPlayer.
	player ifNotNil:[player noticeRemovalOf: self].
	^super delete