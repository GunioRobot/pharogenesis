fixUpProblemsWithAllCategory
	"Moves all methods that are in formally classified a category named '-- all --' into the default 'as yet unclassified' category"

	"Utilities fixUpProblemsWithAllCategory"

	| org aCategory methodCount classCount any |
	self flag: #ShouldBeMovedInClassOrganization.
	methodCount _ 0.
	classCount _ 0.
	self systemNavigation allBehaviorsDo:
		[:aClass | org _ aClass organization.
			(org categories includes: #'-- all --') ifTrue:
				[any _ false.
				aClass selectorsDo:
					[:aSelector |
						aCategory _ org categoryOfElement: aSelector.
						aCategory = #'-- all --' ifTrue:
							[org classify: aSelector under: ClassOrganizer default suppressIfDefault: false.
							Transcript cr; show: aClass name, ' >> ', aSelector.
							methodCount _ methodCount + 1.
							any _ true]].
			any ifTrue: [classCount _ classCount + 1].
			org removeEmptyCategories]].
	Transcript cr; show: methodCount printString, ' methods in ', classCount printString, ' classes moved from "-- all --" to "as yet unclassified"'
