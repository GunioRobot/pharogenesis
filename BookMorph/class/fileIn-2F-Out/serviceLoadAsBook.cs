serviceLoadAsBook

	^ SimpleServiceEntry 
			provider: self 
			label: 'load as book'
			selector: #openFromFile:
			description: 'open as bookmorph'