getMenuShifted
	"Answer the other menu for this text view, supplying an empty menu to be filled in. If the menu selector takes an extra argument, pass in the current state of the shift key."

	| menu |
	getMenuSelector == nil ifTrue: [^ nil].
	menu _ CustomMenu new.
	getMenuSelector numArgs = 1
		ifTrue: [^ nil].	"Need the other menu"
	getMenuSelector numArgs = 2
		ifTrue: [^ model perform: getMenuSelector with: menu with: true].
	^ nil