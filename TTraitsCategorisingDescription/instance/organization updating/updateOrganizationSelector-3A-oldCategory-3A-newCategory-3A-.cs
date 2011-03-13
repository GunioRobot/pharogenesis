updateOrganizationSelector: aSymbol oldCategory: oldCategoryOrNil newCategory: newCategoryOrNil
	| currentCategory effectiveCategory sel changedCategories composition |
	changedCategories _ IdentitySet new.
	composition := self hasTraitComposition
		ifTrue: [self traitComposition]
		ifFalse: [TraitComposition new].
	(composition methodDescriptionsForSelector: aSymbol) do: [:each |
		sel _ each selector.
		(self includesLocalSelector: sel) ifFalse: [
			currentCategory _ self organization categoryOfElement: sel.
			effectiveCategory _ each effectiveMethodCategoryCurrent: currentCategory new: newCategoryOrNil.
			effectiveCategory isNil ifTrue: [
				currentCategory ifNotNil: [changedCategories add: currentCategory].
				self organization removeElement: sel.
			] ifFalse: [
				((currentCategory isNil or: [currentCategory == ClassOrganizer ambiguous or: [currentCategory == oldCategoryOrNil]]) and: [currentCategory ~~ effectiveCategory]) ifTrue: [
					currentCategory ifNotNil: [changedCategories add: currentCategory].
					self organization 
						classify: sel 
						under: effectiveCategory
						suppressIfDefault: false]]]].
	^ changedCategories