findDirtyWindows: evt
	"Present a menu of window titles for all windows with changes,
	and activate the one that gets chosen."
	| menu |
	menu _ MenuMorph new.
	(SystemWindow windowsIn: self
		satisfying: [:w | w model canDiscardEdits not])
		do: [:w | menu add: w label target: w action: #activate].

	menu submorphs size > 0 ifTrue:
		[menu popUpEvent: evt in: self]