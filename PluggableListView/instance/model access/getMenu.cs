getMenu
	"Answer the menu for this list view."

	getMenuSelector == nil ifTrue: [^ nil].
	^ model perform: getMenuSelector