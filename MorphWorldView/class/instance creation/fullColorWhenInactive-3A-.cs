fullColorWhenInactive: fullColor
	"MorphWorldView fullColorWhenInactive: true"
	"If FullColorWhenInactive is true then WorldMorphViews will created inside StandardSystemViews that cache their contents in full-color when the window is inactive. If it is false, only a half-tone gray approximation of the colors will be cached to save space."

	FullColorWhenInactive _ fullColor.

	"Retroactively convert all extant windows"
	((fullColor ifTrue: [StandardSystemView] ifFalse: [ColorSystemView])
		allInstances select:
			[:v | v subViews notNil and: [v subViews isEmpty not and: [v firstSubView isKindOf: MorphWorldView]]])
		do: [:v | v uncacheBits.
			v controller toggleTwoTone]