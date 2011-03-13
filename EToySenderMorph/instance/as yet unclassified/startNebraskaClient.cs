startNebraskaClient

	| newMorph |
	[
		[
			newMorph _ NetworkTerminalMorph connectTo: self ipAddress.
			WorldState addDeferredUIMessage: [newMorph openInStyle: #scaled] fixTemps.
		]
			on: Error
			do: [ :ex |
				WorldState addDeferredUIMessage: [
					self inform: 'No connection to: '. self ipAddress,' (',ex printString,')'
				] fixTemps
			].
	] fork
