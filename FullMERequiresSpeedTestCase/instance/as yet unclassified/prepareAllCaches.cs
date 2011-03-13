prepareAllCaches
	| classes |
	classes := displayedClasses , focusedClasses.
	self noteInterestInClasses: classes.
	self getInformationFor: classes