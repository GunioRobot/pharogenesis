mouseUp: evt

	ignoreNextUp == true ifTrue: [ignoreNextUp _ false. ^self].
	^super mouseUp: evt
