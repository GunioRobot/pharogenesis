inlineInMenu: aMenu for: aServiceCategory 
	menu addLast: aMenu.
	aServiceCategory enabledServices
		do: [:each | self menuItemFor: each].
	^ self popMenu