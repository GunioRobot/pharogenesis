test3

	| m |

	(m _ self ellipticalButtonWithText: 'Hello world') openInWorld.
	m ensuredButtonProperties
		target: Beeper;
		actionSelector: #beep;
		delayBetweenFirings: 1000.