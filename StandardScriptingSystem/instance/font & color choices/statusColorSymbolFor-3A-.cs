statusColorSymbolFor: statusSymbol
	#(	(normal				green)
		(ticking				blue)
		(paused				red)
		(mouseDown			yellow)
		(mouseStillDown		lightYellow)
		(mouseUp			lightBlue)
		(mouseEnter			lightBrown)
		(mouseLeave		lightRed)
		(keyStroke			lightGreen)) do:

			[:pair | statusSymbol == pair first ifTrue: [^ pair second]].

		^ #blue