tabSelected
	"Called when the receiver is hit.  First, bulletproof against someone having taken the structure apart.  My own action basically requires that my grand-owner be a TabbedPalette"
	self player ifNotNil: [self player runAllOpeningScripts ifTrue: [^ self]].
	(owner isKindOf: IndexTabs) ifFalse: [^ self beep].
	(owner owner isKindOf: TabbedPalette) ifFalse: [^ self beep].
	owner owner selectTab: self