offerWhatToShowMenu
	"Offer a menu governing what to show"
	| aMenu |
	aMenu := MenuMorph new defaultTarget: self.
	aMenu addTitle: 'What to show' translated.
	aMenu addStayUpItem.
	self addContentsTogglesTo: aMenu.
	aMenu popUpInWorld