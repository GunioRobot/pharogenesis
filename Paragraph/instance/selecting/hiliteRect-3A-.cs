hiliteRect: rect
	(rect ~~ nil) ifTrue:
		[ destinationForm
			fill: rect
			rule: Form reverse
			fillColor: destinationForm highLight.
		"destinationForm
			fill: (rect translateBy: 1@1)
			rule: Form reverse
			fillColor: destinationForm highLight" ].
