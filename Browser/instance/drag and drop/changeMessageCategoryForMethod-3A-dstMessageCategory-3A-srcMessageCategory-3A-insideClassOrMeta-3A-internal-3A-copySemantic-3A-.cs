changeMessageCategoryForMethod: methodSel dstMessageCategory: dstMessageCategorySel srcMessageCategory: srcMessageCategorySel insideClassOrMeta: classOrMeta internal: internal copySemantic: copyFlag 
	"only move semantic"
	| success messageCategorySel |
	(success _ copyFlag not) ifFalse: [^ false].
	messageCategorySel _ dstMessageCategorySel ifNil: [srcMessageCategorySel].
	(success _ messageCategorySel notNil & (messageCategorySel ~= '-- all --' asSymbol)
				and: [messageCategorySel ~= srcMessageCategorySel and: [classOrMeta organization categories includes: messageCategorySel]])
		ifTrue: 
			[classOrMeta organization
				classify: methodSel
				under: messageCategorySel
				suppressIfDefault: false.
			self changed: #messageList].
	success & internal not ifTrue: [self setSelector: methodSel].
	^ success