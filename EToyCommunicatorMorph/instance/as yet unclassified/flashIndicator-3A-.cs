flashIndicator: aSymbol

	| now |

	now _ Time millisecondClockValue.
	(LastFlashTime notNil and: [(Time millisecondClockValue - now) abs < 500]) ifTrue: [^self].
	LastFlashTime _ now.
	self trulyFlashIndicator: aSymbol
