updateShortcut
	(self systemNavigation allImplementorsOf: #processService:newShortcut:) 
		do: [:ref | | cls |
			cls := ref actualClass.
			cls isMeta ifTrue: [cls soleInstance processService: self newShortcut: self shortcut]].
	ServiceRegistry ifInteractiveDo: [self provider savePreferencesFor: self]