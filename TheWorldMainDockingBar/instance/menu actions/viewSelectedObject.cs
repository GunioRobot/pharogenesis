viewSelectedObject
	| selected menu |
	selected := self world selectedObject.
	selected isNil
		ifTrue: [^ self viewObjectsHierarchy].
	""
	menu := selected buildYellowButtonMenu: ActiveHand.
	menu
		addTitle: selected externalName
		icon: (selected iconOrThumbnailOfSize: (Preferences tinyDisplay ifTrue: [16] ifFalse: [28])).
	menu popUpInWorld: selected currentWorld