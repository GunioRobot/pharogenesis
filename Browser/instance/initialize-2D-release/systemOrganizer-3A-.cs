systemOrganizer: aSystemOrganizer
	"Initialize the receiver as a perspective on the system organizer, 
	aSystemOrganizer. Typically there is only one--the system variable 
	SystemOrganization."

	contents _ nil.
	systemOrganizer _ aSystemOrganizer.
	systemCategoryListIndex _ 0.
	classListIndex _ 0.
	messageCategoryListIndex _ 0.
	messageListIndex _ 0.
	metaClassIndicated _ false.
	self setClassOrganizer.
	self editSelection: #none.