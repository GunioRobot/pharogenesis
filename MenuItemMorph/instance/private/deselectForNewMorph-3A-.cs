deselectForNewMorph: aMorph
	aMorph == owner
		ifTrue: [^ self isSelected: false].   "in my menu but not over any item"
	(aMorph == subMenu or: [aMorph owner == subMenu])
		ifTrue: [^ self].  "selecting my submenu or an item in it, leave me selected"

	self isSelected: false.
	subMenu ifNotNil: [subMenu stayUp ifFalse: [subMenu delete]].

	self deletePopupBackToCommonMenuWith: aMorph.
	aMorph owner ~= self owner ifFalse: [
		self deletePopupBackToCommonMenuWith: aMorph].
