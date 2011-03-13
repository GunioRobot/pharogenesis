createNewService
	^ ServiceAction 
		text: 'Create new service' 
		button: 'new service' 
		description: 'Define a new service provided by this package' 
		action: [:r | | s p |
			s := r caption: 'enter service identifier'; getSymbol.
			p := r getPackageProvider.
			p compile: s, ' 
	^ ServiceAction 
		"Open the service browser to set the menu position and the keyboard shortcut"
		text: ''fill menu label''
		button: ''short button text''
		description: ''longer text for balloon help''
		action: [:r | "action block"]
		condition: [:r | "optional condition block"]' classified: 'services'.
			r getBrowser browseReference: (MethodReference class: p selector: s)]