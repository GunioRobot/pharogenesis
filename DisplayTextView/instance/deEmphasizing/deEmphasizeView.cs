deEmphasizeView 
	"Refer to the comment in View|deEmphasizeView."

	(self controller isKindOf: ParagraphEditor)
	 	ifTrue: [controller deselect]