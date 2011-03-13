buildPluggableMenuItem: itemSpec
	| item action label menu |
	item _ MenuItemMorph new.
	label := itemSpec label.
	itemSpec checked ifTrue:[label := '<on>', label] ifFalse:[label := '<off>', label].
	item contents: label.
	item isEnabled: itemSpec enabled.
	(action := itemSpec action) ifNotNil:[
		item 
			target: action receiver;
			selector: action selector;
			arguments: action arguments.
	].
	(menu := itemSpec subMenu) ifNotNil:[
		item subMenu: (menu buildWith: self).
	].
	parentMenu ifNotNil:[parentMenu addMorphBack: item].
	^item