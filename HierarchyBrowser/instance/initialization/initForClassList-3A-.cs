initForClassList: classNames
	"Initialize the receiver for use with the provided list of class names.   "

	self systemOrganizer: SystemOrganization.
	metaClassIndicated _ false.
	classList _ classNames