hasSubMenu: aMenuMorph

	| sub |
	self items do: [:each |
		sub _ each subMenu.
		sub ifNotNil: [
			sub == aMenuMorph ifTrue: [^ true].
			(sub hasSubMenu: aMenuMorph) ifTrue: [^ true]]].
	^ false
