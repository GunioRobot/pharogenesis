addScriptHandle: haloSpec
	(Preferences valueOfFlag: #nascentScriptHaloHandle) ifTrue:
		[self addHandle: haloSpec
				on: #mouseDown send: #makeNascentScript to: innerTarget].
