loadPurpleWalt
	"Read in the old 'Walt Disney Imagineering' picture."
	"EToySystem loadPurpleWalt"

	| f |
	f _ FileStream oldFileNamed: 'purpleWalt.morph'.
	self formDictionary at: 'ImagiPic' put: f fileInObjectAndCode image
