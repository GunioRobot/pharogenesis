browseAllVersionsOfSelections
	"Opens a Versions browser on all the currently selected methods, showing each alongside all of their historical versions."
	|  oldSelection aList |
	oldSelection _ self listIndex.
	aList _ OrderedCollection new.
	Cursor read showWhile: [
		1 to: changeList size do: [:i |
			(listSelections at: i) ifTrue: [
				listIndex _ i.
				self browseVersions.
				aList add: i.
				]]].
	listIndex _ oldSelection.

	aList size == 0 ifTrue: [^ self inform: 'no selected methods have in-memory counterparts'].
