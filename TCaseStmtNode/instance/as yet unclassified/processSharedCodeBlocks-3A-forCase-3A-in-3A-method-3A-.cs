processSharedCodeBlocks: caseTree forCase: caseIndex in: codeGen method: aTMethod
	"Process any shared code blocks in the case parse tree for the given case, either inlining them or making them a 'goto sharedLabel'."
	| map meth sharedNode exitLabel |
	exitLabel _ nil.

	[sharedNode _ nil.
	map _ IdentityDictionary new.
	caseTree nodesDo:[:node|
		(node isSend 
			and:[(meth _ codeGen methodNamed: node selector) notNil
			and:[meth sharedCase notNil]]) ifTrue:[
			meth sharedCase = caseIndex ifTrue:[
				sharedNode _ meth.
				map at: node put: (TLabeledCommentNode new setComment: 'goto ', meth sharedLabel).
			] ifFalse:[
				map at: node put: (TGoToNode new setLabel: meth sharedLabel).
			].
		].
	].
	caseTree replaceNodesIn: map.
	"recursively expand"
	sharedNode == nil] whileFalse:[
		meth _ sharedNode copy.
		(meth hasReturn) ifTrue: [
			exitLabel ifNil:[
				exitLabel _ aTMethod unusedLabelForInliningInto: aTMethod.
				aTMethod labels add: exitLabel.
			].
			meth exitVar: nil label: exitLabel.
		].
		meth renameLabelsForInliningInto: aTMethod.
		aTMethod labels addAll: meth labels.
		caseTree setStatements: (caseTree statements copyWith: meth asInlineNode).
	].
	exitLabel ifNotNil:[
		caseTree setStatements: (caseTree statements copyWith:
			(TLabeledCommentNode new setLabel: exitLabel comment: 'end case')).

	].