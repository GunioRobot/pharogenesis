classFromPattern: pattern withCaption: aCaption
	"If there is a class whose name exactly given by pattern, return it.
	If there is only one class in the system whose name matches pattern, return it.
	Otherwise, put up a menu offering the names of all classes that match pattern, and return the class chosen, else nil if nothing chosen.
	This method ignores tab, space, & cr characters in the pattern"

	self deprecated: 'Use SystemNavigation>>classFromPattern: pattern withCaption: aCaption'.
	^ SystemNavigation default classFromPattern: pattern withCaption: aCaption.