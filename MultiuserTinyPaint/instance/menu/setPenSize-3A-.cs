setPenSize: evt

	| menu sizes |
	menu _ MenuMorph new.
	sizes _ (0 to: 5), (6 to: 12 by: 2), (15 to: 40 by: 5).
	sizes do: [:w |
		menu add: w printString
			target: self
			selector: #penSize:hand:
			argumentList: (Array with: w with: evt hand)].

	menu popUpEvent: evt in: self world