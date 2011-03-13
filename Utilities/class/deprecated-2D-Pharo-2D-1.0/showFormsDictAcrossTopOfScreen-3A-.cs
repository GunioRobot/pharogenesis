showFormsDictAcrossTopOfScreen: formDict
	"Display the given Dictionary of forms across the top of the screen, wrapping to subsequent lines if needed.  Beneath each, put the name of the associated key."

	"
	| dict methods |
	dict := Dictionary new. 
	methods := MenuIcons class selectors select: [:each | '*Icon' match: each asString].
	methods do: [:each | dict at: each put: (MenuIcons perform: each)].
	Form showFormsDictAcrossTopOfScreen: dict"

	self deprecated: 'Use ''Form showFormsDictAcrossTopOfScreen:'' instead.' on: '10 July 2009' in: #Pharo1.0.
	^ Form showFormsDictAcrossTopOfScreen: formDict

