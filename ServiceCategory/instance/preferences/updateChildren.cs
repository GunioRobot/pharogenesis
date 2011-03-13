updateChildren

	self newChildrenValid
		ifTrue: [self replaceChildren].
	"PreferenceBrowserMorph updateBrowsers."
	ServiceGui updateBar: self