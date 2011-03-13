unloadClasses: aWorkingCopy
	aWorkingCopy packageInfo classes do: [ :class |
		(class selectors includes: #unload)
			ifTrue: [ class unload ] ]