displayView 
	"Refer to the comment in View|displayView."

	| aClass sel index baseClass |
	Browser postOpenSuggestion == nil ifFalse:
		["Set the class and message"
		aClass _ Browser postOpenSuggestion first.
		sel _ Browser postOpenSuggestion last.
		Browser postOpenSuggestion: nil.
		baseClass _ aClass theNonMetaClass.
		model systemCategoryListIndex:
			(SystemOrganization numberOfCategoryOfElement: baseClass name).
		model selectClass: baseClass.
		model metaClassIndicated: aClass isMeta.
		(sel notNil and: [aClass includesSelector: sel]) ifTrue:
			[model messageCategoryListIndex:
				(index _ aClass organization numberOfCategoryOfElement: sel).
			model messageListIndex: 
				((aClass organization listAtCategoryNumber: index) indexOf: sel)].
		self topView deEmphasize.
		^ self   "a redisplay has already been done"].
	super displayView