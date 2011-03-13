replaceChildren
	ServiceRegistry ifInteractiveDo: [services
		do: [:s | s provider
				ifNotNil: [:p | p class removeSelector: (self id , s id) asSymbol]]].
	services := self newChildren.
	services
		do: [:e | 
			(ServicePreferences preferenceAt: e shortcutPreference)
				ifNotNil: [:p | p categoryList: {'-- keyboard shortcuts --'. self id asString}].
			ServiceRegistry
				ifInteractiveDo: [self provider savePreferencesFor: self]]