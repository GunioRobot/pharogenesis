tabSelected
	"Called when the receiver is hit.  First, bulletproof against someone having taken the structure apart.  My own action basically requires that my grand-owner be a TabbedPalette.  Note that the 'opening' script concept has been left behind here."
	| gramps |
	(owner isKindOf: IndexTabs) ifFalse: [^ self beep].
	((gramps _ owner owner) isKindOf: TabbedPalette)  ifTrue:
		[gramps selectTab: self]