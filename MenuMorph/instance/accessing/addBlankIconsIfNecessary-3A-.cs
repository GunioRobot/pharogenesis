addBlankIconsIfNecessary: anIcon
	"If any of my items have an icon, ensure that all do by using anIcon for those that don't"

	| withIcons withoutIcons |
	withIcons _ Set new.
	withoutIcons _ Set new.
	self items do: [ :item |
		item hasIconOrMarker
			ifTrue: [ withIcons add: item ]
			ifFalse: [ withoutIcons add: item ].
		item hasSubMenu ifTrue: [ item subMenu addBlankIconsIfNecessary: anIcon ]].
	(withIcons isEmpty or: [ withoutIcons isEmpty ]) ifTrue: [ ^self ].
	withoutIcons do: [ :item | item icon: anIcon ].