replaceChildren
	ServiceRegistry ifInteractiveDo: [services
		do: [:s | s provider
				ifNotNilDo: [:p | p class removeSelector: (self id , s id) asSymbol]]].
	services _ self newChildren.
	services
		do: [:e | 
			(ServicePreferences preferenceAt: e shortcutPreference)
				ifNotNilDo: [:p | p categoryList: {'-- keyboard shortcuts --'. self id asString}].
			ServiceRegistry
				ifInteractiveDo: [self provider savePreferencesFor: self]]