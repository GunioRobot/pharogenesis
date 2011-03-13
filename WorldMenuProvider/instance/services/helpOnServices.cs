helpOnServices
	^ ServiceAction
		text: 'Help on Services'
		button: 'services help'
		description: 'Introductory text about services'
		action: [StringHolder new contents: self servicesHelpText; openLabel: 'Introduction to Services'].