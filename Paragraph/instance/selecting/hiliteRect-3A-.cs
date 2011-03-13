hiliteRect: rect

	| highlightColor |
	highlightColor := Color quickHighLight: destinationForm depth.
	rect ifNotNil: [
		destinationForm
			fill: rect
			rule: Form reverse
			fillColor: highlightColor.
		"destinationForm
			fill: (rect translateBy: 1@1)
			rule: Form reverse
			fillColor: highlightColor" ].
