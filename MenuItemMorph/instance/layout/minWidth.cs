minWidth
	| fontToUse iconWidth subMenuWidth markerWidth |
	fontToUse := self fontToUse.
	subMenuWidth := self hasSubMenu
				ifFalse: [0]
				ifTrue: [10].
	iconWidth := self hasIcon
				ifTrue: [self icon width + 2]
				ifFalse: [0].
	markerWidth := self hasMarker
		ifTrue: [ self submorphBounds width + 8 ]
		ifFalse: [ 0 ].
	^ (fontToUse widthOfString: contents)
		+ subMenuWidth + iconWidth + markerWidth.