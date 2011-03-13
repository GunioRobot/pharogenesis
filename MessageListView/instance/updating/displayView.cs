displayView 
	"Refer to the comment in View|displayView."

	| aClass sel index baseClass |
	Browser postOpenSuggestion == nil ifFalse: [
		"Set the class and message"
		aClass _ Browser postOpenSuggestion first.
		sel _ Browser postOpenSuggestion last.
		Browser postOpenSuggestion: nil.
		baseClass _ aClass theNonMetaClass.
		index _ SystemOrganization numberOfCategoryOfElement: baseClass name.
		model metaClassIndicated: aClass isMeta.
		model systemCategoryListIndex: index.
		model metaClassIndicated: aClass isMeta.
		model classListIndex: ((SystemOrganization listAtCategoryNumber: index)
				findFirst: [:each | each == baseClass name]).
		sel notNil ifTrue: [
			index _ aClass organization numberOfCategoryOfElement: sel.
			model messageCategoryListIndex: index.
			model messageListIndex: 
				((aClass organization listAtCategoryNumber: index) indexOf: sel)
			].
		^ self topView deEmphasize.   "a redisplay has already been done"
		].
	super displayView.