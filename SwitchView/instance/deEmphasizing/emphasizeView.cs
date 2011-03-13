emphasizeView 
	"See View|deEmphasizeView."
	highlightForm == nil
		ifTrue: [self interrogateModel ifTrue: [self displayComplemented]]
		ifFalse: [self displaySpecial]