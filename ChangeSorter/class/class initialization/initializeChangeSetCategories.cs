initializeChangeSetCategories
	"Initialize the set of change-set categories"
	"ChangeSorter initializeChangeSetCategories"

	| aCategory |
	ChangeSetCategories := ElementCategory new categoryName: #ChangeSetCategories.

	aCategory := ChangeSetCategory new categoryName: #All.
	aCategory membershipSelector: #belongsInAll:.
	aCategory documentation: 'All change sets known to the system'.
	ChangeSetCategories addCategoryItem: aCategory.

	aCategory := ChangeSetCategory new categoryName: #Additions.
	aCategory membershipSelector: #belongsInAdditions:.
	aCategory documentation: 'All unnumbered change sets except those representing projects in the system as initially released.'.
	ChangeSetCategories addCategoryItem: aCategory.

	aCategory := ChangeSetCategory new categoryName: #MyInitials.
	aCategory membershipSelector: #belongsInMyInitials:.
	aCategory documentation: 'All change sets whose names end with the current author''s initials.'.
	ChangeSetCategories addCategoryItem: aCategory.

	aCategory := ChangeSetCategory new categoryName: #Numbered.
	aCategory membershipSelector: #belongsInNumbered:.
	aCategory documentation: 'All change sets whose names start with a digit -- normally these will be the official updates to the system.'.
	ChangeSetCategories addCategoryItem: aCategory.

	aCategory := ChangeSetCategory new categoryName: #ProjectChangeSets.
	aCategory membershipSelector: #belongsInProjectChangeSets:.
	aCategory documentation: 'All change sets that are currently associated with projects present in the system right now.'.
	ChangeSetCategories addCategoryItem: aCategory.

	aCategory := ChangeSetCategory new categoryName: #ProjectsInRelease.
	aCategory membershipSelector: #belongsInProjectsInRelease:.
	aCategory documentation: 'All change sets belonging to projects that were shipped in the initial release of this version of Squeak'.
	ChangeSetCategories addCategoryItem: aCategory.

	aCategory := ChangeSetCategory new categoryName: #RecentUpdates.
	aCategory membershipSelector: #belongsInRecentUpdates:.
	aCategory documentation: 'Updates whose numbers are at or beyond the number I have designated as the earliest one to qualify as Recent'.
	ChangeSetCategories addCategoryItem: aCategory.

	ChangeSetCategories elementsInOrder do: [:anElem | anElem reconstituteList] 