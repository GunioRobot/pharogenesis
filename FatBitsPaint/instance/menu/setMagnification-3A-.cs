setMagnification: evt

	| menu |
	menu _ MenuMorph new.
	((1 to: 8), #(16 24 32)) do: [:w |
		menu add: w printString
			target: self
			selector: #magnification:
			argumentList: (Array with: w)].

	menu popUpAt: evt hand position event: evt.
