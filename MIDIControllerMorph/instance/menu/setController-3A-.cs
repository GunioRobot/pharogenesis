setController: evt
	| menu |
	menu _ MenuMorph new.
	self controllerList do: [:pair |
		menu add: (pair last)
			target: self
			selector: #controller:
			argumentList: (Array with: pair first)].

	menu popUpEvent: evt in: self world