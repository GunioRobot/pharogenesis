step

	(flash or: [flashing])
		ifTrue:
			[flashing _ flashing not.
			self highlighted: flashing]