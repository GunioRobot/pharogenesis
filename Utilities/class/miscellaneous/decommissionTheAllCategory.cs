decommissionTheAllCategory
	"Utilities decommissionTheAllCategory"
	"Moves all methods that are in a category named 'all' into the default 'as yet unclassified' category"

	| org aCategory methodCount classCount any |
	methodCount _ 0.
	classCount _ 0.
	Smalltalk allBehaviorsDo:
		[:aClass | org _ aClass organization.
			any _ false.
			aClass selectorsDo:
				[:aSelector |
					aCategory _ org categoryOfElement: aSelector.
					aCategory = #all ifTrue:
						[org classify: aSelector under: ClassOrganizer default suppressIfDefault: false.
						methodCount _ methodCount + 1.
						any _ true]].
			any ifTrue: [classCount _ classCount + 1].
			org removeEmptyCategories].
	Transcript cr; show: methodCount printString, ' methods in ', classCount printString, ' classes moved
from "all" to "as yet unclassified"'
