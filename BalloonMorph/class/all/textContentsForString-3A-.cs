textContentsForString: str
	BalloonFont ifNotNil: [^ Text string: str attribute: (TextFontReference toFont: BalloonFont)].
	^ str