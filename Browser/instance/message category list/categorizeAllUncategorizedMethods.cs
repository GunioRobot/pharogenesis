categorizeAllUncategorizedMethods
	"Categorize methods by looking in parent classes for a method category."

	| organizer organizers |
	organizer _ self classOrMetaClassOrganizer.
	organizers _ self selectedClassOrMetaClass withAllSuperclasses collect: [:ea | ea organization].
	(organizer listAtCategoryNamed: ClassOrganizer default) do: [:sel | | found |
		found _ (organizers collect: [ :org | org categoryOfElement: sel])
			detect: [:ea | ea ~= ClassOrganizer default and: [ ea ~= nil]]
			ifNone: [].
		found ifNotNil: [organizer classify: sel under: found]].

	self changed: #messageCategoryList