setPenSize: evt

	| menu sizes |
	menu _ MenuMorph new.
	sizes _ (1 to: 5), (6 to: 12 by: 2), (15 to: 40 by: 5).
	sizes do: [:w |
		menu add: w printString
			target: self
			selector: #penSize:
			argumentList: (Array with: w)].

	menu popUpAt: evt hand position event: evt.
