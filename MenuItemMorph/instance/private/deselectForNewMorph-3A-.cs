deselectForNewMorph: aMorph

	aMorph == owner ifTrue: [^ self].   "in my menu but not over any item"
	(aMorph == subMenu or: [aMorph owner == subMenu])
		ifTrue: [^ self].  "selecting my submenu or an item in it, leave me selected"

	isSelected _ false.
	self changed.
	subMenu ifNotNil: [subMenu stayUp ifFalse: [subMenu delete]].

	self deletePopupBackToCommonMenuWith: aMorph.
	aMorph owner ~= self owner ifFalse: [
		self deletePopupBackToCommonMenuWith: aMorph].
