findDirtyBrowsers
	"Present a menu of window titles for browsers with changes,
	and activate the one that gets chosen."
	| menu |
	menu _ MenuMorph new.
	(SystemWindow windowsIn: self world
		satisfying: [:w | (w model isKindOf: Browser) and: [w model canDiscardEdits not]])
		do: [:w | menu add: w label target: w action: #activate].
	menu submorphs size > 0 ifTrue:
		[self invokeMenu: menu event: lastEvent]