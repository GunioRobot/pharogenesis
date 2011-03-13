deEmphasizeView 
	"See View|deEmphasizeView."
	highlightForm == nil
		ifTrue: [self interrogateModel ifTrue: [self displayNormal]]
		ifFalse: [self displaySpecial]