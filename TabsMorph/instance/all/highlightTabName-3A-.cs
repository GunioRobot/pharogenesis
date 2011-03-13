highlightTabName: aString
	| theOne |
	self stringButtonSubmorphs do: [:m |
		(m isKindOf: StringButtonMorph) ifTrue:
			[(m contents beginsWith: aString)
				ifTrue: [m color: m buttonOnColor.  theOne _ m]
				ifFalse: [m color: m buttonOffColor]]].
	^ theOne
