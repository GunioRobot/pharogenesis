levelMessage
	| number message |
	number _ self availableMaps indexOf: currentMap class.
	message _ 'Level ' translated, number asString.
	currentMap mapStyle
		isSmallScreen ifFalse: [message _ message , ': ' , currentMap levelName].
	^ message