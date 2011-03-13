chooseTheme
	" 
	SmallLandColorTheme chooseTheme.  
	"
	| themes menu |
	menu := MenuMorph new defaultTarget: self.
	menu addTitle: 'choose color theme' translated.
	Preferences noviceMode
		ifFalse: [menu addStayUpItem].
	""
	themes := self allThemes
				asSortedCollection: [:x :y | x themeName translated <= y themeName translated].
	themes
		do: [:each | ""menu
				addUpdating: #stringForTheme:
				target: each
				selector: #applyTheme:
				argumentList: {each}].
	""
	menu popUpInWorld