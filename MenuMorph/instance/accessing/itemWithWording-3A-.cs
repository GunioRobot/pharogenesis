itemWithWording: wording
	| aString aSubmenu subItem |
	"If any of the receiver's items or submenu items have the given wording (case-blind comparison done), then return it, else return nil."

	aString _ wording asString asLowercase.
	self items do:
		[:anItem |
			(anItem contents asString asLowercase = aString) ifTrue: [^ anItem].
			(aSubmenu _ anItem subMenu) ifNotNil:
				[(subItem _ aSubmenu itemWithWording: wording) ifNotNil: [^ subItem]]].
	^ nil