timeout
	timeout ifNil: [timeout := Socket standardTimeout].
	^timeout