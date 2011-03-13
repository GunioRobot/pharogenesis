initialize
	#(
	(inlineServicesInMenu true 'Inline the services the squeak menus') 
	(useOnlyServicesInMenu false 'Use only services and not regular menu items')
	(useServicesInBrowserButtonBar false 'Use a service-based button bar')) 
		do: [:tr |
				Preferences 
						addPreference: tr first
						categories: #(#services)
						default: tr second
						balloonHelp: tr third] 
	