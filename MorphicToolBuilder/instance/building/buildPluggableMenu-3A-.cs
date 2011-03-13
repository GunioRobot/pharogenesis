buildPluggableMenu: menuSpec 
	| prior menu |
	prior := parentMenu.
	parentMenu := menu := MenuMorph new.
	menuSpec label ifNotNil:[parentMenu addTitle: menuSpec label].
	menuSpec items do:[:each| each buildWith: self].
	parentMenu := prior.
	^menu