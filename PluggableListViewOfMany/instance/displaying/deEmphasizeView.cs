deEmphasizeView 
	"Refer to the comment in View|deEmphasizeView."
	selection _ 0.
	1 to: self maximumSelection do:
		[:i | selection _ i.
		(self listSelectionAt: i) ifTrue: [self deEmphasizeSelectionBox]].
	selection _ 0