offerWhatToShowMenu
	"Offer a menu governing what to show"
	| aMenu |
	Smalltalk isMorphic
		ifTrue: [aMenu := MenuMorph new defaultTarget: self.
			aMenu addTitle: 'What to show' translated.
			aMenu addStayUpItem.
			self addContentsTogglesTo: aMenu.
			aMenu popUpInWorld]
		ifFalse: [aMenu := CustomMenu new.
			self addContentsTogglesTo: aMenu.
			aMenu title: 'What to show' translated.
			aMenu invokeOn: self.
			self changed: #contents ]