example2
	"EmphasizedMenu example2"

	| aMenu |
	aMenu _ EmphasizedMenu selections: #('One' 'Two' 'Three' 'Four').
	aMenu onlyBoldItem: 3.
	^ aMenu startUpWithCaption: 'Only the Bold'