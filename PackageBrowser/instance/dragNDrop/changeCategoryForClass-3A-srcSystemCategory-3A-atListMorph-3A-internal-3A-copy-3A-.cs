changeCategoryForClass: class srcSystemCategory: srcSystemCategorySel atListMorph: dstListMorph internal: internal copy: copyFlag 
	"only move semantic"
	| newClassCategory success |
	self flag: #stringSymbolProblem.
	success _ copyFlag not ifFalse: [^ false].
	newClassCategory _ self dstCategoryDstListMorph: dstListMorph internal: internal.
	(success _ newClassCategory notNil & (newClassCategory ~= class category))
		ifTrue: 
			[class category: newClassCategory.
			self changed: #classList.
			internal ifFalse: [self selectClass: class]].
	^ success