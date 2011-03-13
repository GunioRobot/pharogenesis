servicesBrowser
	^ ServiceAction text: 'Services Browser' button: 'services' description: 'Open a preference browser to edit several Squeak menus' action: [PreferenceBrowser openForServices].