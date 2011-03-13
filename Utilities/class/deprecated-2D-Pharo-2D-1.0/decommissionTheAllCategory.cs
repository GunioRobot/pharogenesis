decommissionTheAllCategory
	"Utilities decommissionTheAllCategory"
	"Moves all methods that are in a category named 'all' into the default 'as yet unclassified' category"

	| org aCategory methodCount classCount any |
	self deprecated: 'No alternative is suggested.' on: '10 July 2009' in: #Pharo1.0.
	
	methodCount := 0.
	classCount := 0.
	self systemNavigation allBehaviorsDo:
		[:aClass | org := aClass organization.
			any := false.
			aClass selectorsDo:
				[:aSelector |
					aCategory := org categoryOfElement: aSelector.
					aCategory = #all ifTrue:
						[org classify: aSelector under: ClassOrganizer default suppressIfDefault: false.
						methodCount := methodCount + 1.
						any := true]].
			any ifTrue: [classCount := classCount + 1].
			org removeEmptyCategories].
	Transcript cr; show: methodCount printString, ' methods in ', classCount printString, ' classes moved
from "all" to "as yet unclassified"'
