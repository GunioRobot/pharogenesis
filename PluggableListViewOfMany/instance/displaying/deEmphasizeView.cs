deEmphasizeView 
	"Refer to the comment in View|deEmphasizeView."
	selection := 0.
	1 to: self maximumSelection do:
		[:i | selection := i.
		(self listSelectionAt: i) ifTrue: [self deEmphasizeSelectionBox]].
	selection := 0