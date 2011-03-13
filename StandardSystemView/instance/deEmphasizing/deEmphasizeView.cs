deEmphasizeView 
	"Refer to the comment in View|deEmphasizeView."

	isLabelComplemented ifTrue:
		[self deEmphasizeLabel.
		isLabelComplemented := false]