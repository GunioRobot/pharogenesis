setChannel: evt
	| menu |
	menu _ MenuMorph new.
	1 to: 16 do: [:chan |
		menu add: chan printString
			target: self
			selector: #channel:
			argumentList: (Array with: chan - 1)].

	menu popUpEvent: evt