categorySubmenu: aMenu  shifted: shiftedIgnored
	"Fill aMenu with less-frequently-needed category items"
	
	aMenu title: 'Change set category'.
	aMenu addStayUpItem.

	aMenu addList: #(
		('make a new category...' makeNewCategory 'Creates a new change-set-category (you will be asked to supply a name) which will start out its life with this change set in it')
		('make a new category with class...' makeNewCategoryShowingClassChanges 'Creates a new change-set-category that includes change sets that change a particular class (you will be asked to supply a name)')
		('rename this category' renameCategory 'Rename this change-set category.   Only applies when the current category being shown is a manually-maintained, user-defined category, such as you can create for yourself by choosing "make a new category..." from this same menu.')
		('remove this category' removeCategory 'Remove this change-set category.   Only applies when the current category being shown is a manually-maintained, user-defined category, such as you can create for yourself by choosing "make a new category..." from this same menu.')
		('show categories of this changeset' showCategoriesOfChangeSet 'Show a list of all the change-set categories that contain this change-set; if the you choose one of the categories from this pop-up, that category will be installed in this change sorter')
	-).

	parent ifNotNil:
		[aMenu addList: #(
			('add change set to category opposite' addToCategoryOpposite 'Adds this change set to the category on the other side of the change sorter.  Only applies if the category shown on the opposite side is a manually-maintained, user-defined category, such as you can create for yourself by choosing "make a new category..." from this same menu.'))].

	aMenu addList: #(
		('remove change set from this category' removeFromCategory 'Removes this change set from the current category.  Only applies when the current category being shown is a manually-maintained, user-defined category, such as you can create for yourself by choosing "make a new category..." from this same menu.')
		-
		('file out category''s change sets' fileOutAllChangeSets 'File out every change set in this category that has anything in it.  The usual checks for slips are suppressed when this command is done.')
		('set recent-updates marker' setRecentUpdatesMarker 'Allows you to specify a number that will demarcate which updates are considered "recent" and which are not.  This will govern which updates are included in the RecentUpdates category in a change sorter')
		('fill aggregate change set' fillAggregateChangeSet 'Creates a change-set named Aggregate into which all the changes in all the change sets in this category will be copied.')
		-
		('back to main menu' offerUnshiftedChangeSetMenu 'Takes you back to the shifted change-set menu.')
		('back to shifted menu' offerShiftedChangeSetMenu 'Takes you back to the primary change-set menu.')).

	^ aMenu