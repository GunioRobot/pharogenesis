acceptMethod: methodSel messageCategory: srcMessageCategorySel class: srcClassOrMeta atListMorph: dstListMorph internal: internal copy: copyFlag 
	| success dstClassOrMeta dstClass dstMessageCategorySel |
	dstClass _ self dstClassDstListMorph: dstListMorph.
	dstClassOrMeta _ dstClass
				ifNotNil: [self metaClassIndicated
						ifTrue: [dstClass classSide]
						ifFalse: [dstClass]].
	dstMessageCategorySel _ self dstMessageCategoryDstListMorph: dstListMorph.
	success _ (dstClassOrMeta notNil
				and: [dstClassOrMeta == srcClassOrMeta])
						ifTrue: ["one class"
							self
								changeMessageCategoryForMethod: methodSel
								dstMessageCategory: dstMessageCategorySel
								srcMessageCategory: srcMessageCategorySel
								insideClassOrMeta: dstClassOrMeta
								internal: internal
								copySemantic: copyFlag]
						ifFalse: ["different classes"
							self
								acceptMethod: methodSel
								dstMessageCategory: dstMessageCategorySel
								srcMessageCategory: srcMessageCategorySel
								dstClass: dstClass
								dstClassOrMeta: dstClassOrMeta
								srcClassOrMeta: srcClassOrMeta
								internal: internal
								copySemantic: copyFlag].
	^ success