delete
	| player |
	player := self flashPlayer.
	player ifNotNil:[player noticeRemovalOf: self].
	^super delete