minWidth
	| subMenuWidth iconWidth markerWidth margin |
	subMenuWidth := self hasSubMenu
				ifTrue: [10]
				ifFalse: [0].
	iconWidth := self hasIcon
				ifTrue: [self icon width + 2]
				ifFalse: [0].
	markerWidth := self hasMarker
				ifTrue: [self submorphBounds width + 8]
				ifFalse: [0].
	margin := (self isInDockingBar)
				ifTrue: [Preferences tinyDisplay ifFalse:[10] ifTrue:[4]]
				ifFalse: [0].
	^ (self fontToUse widthOfString: contents)
		+ subMenuWidth + iconWidth + markerWidth + margin