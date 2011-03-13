setPreferences
	| mm |
	mm := self map copy.
	(0 to: 9)
		do: [:i | #('ctrl-' 'cmd-' 'ctrl-cmd-' )
				do: [:str | 
					| short | 
					short := (str , i asString) asSymbol.
					self insertPrefShortcut: short]].
	#(#up #down #left #right )
		do: [:s | 
			self insertPrefShortcut: ('ctrl-cmd-' , s) asSymbol.].
	mm
		keysAndValuesDo: [:k :v | ServicePreferences setPreference: k toValue: v].
	((Array new: 3) at: 1 put: ((Array new: 3) at: 1 put: #inlineServicesInMenu;
			 at: 2 put: true;
			 at: 3 put: 'Inline the services the squeak menus';
			 yourself);
		 at: 2 put: ((Array new: 3) at: 1 put: #useOnlyServicesInMenu;
			 at: 2 put: false;
			 at: 3 put: 'Use only services and not regular menu items';
			 yourself);
		 at: 3 put: ((Array new: 3) at: 1 put: #useServicesInBrowserButtonBar;
			 at: 2 put: true;
			 at: 3 put: 'Use a service-based button bar';
			 yourself);
		 yourself)
		do: [:tr | ServicePreferences
				addPreference: tr first
				categories: #('-- settings --' )
				default: tr second
				balloonHelp: tr third]