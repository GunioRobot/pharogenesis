example1
	"Put up a ClassListBrowser that shows all classes that have the string 'Pluggable' in their names"

	self browseClassesSatisfying: [:cl | cl name includesSubString: 'Pluggable'] title: 'Pluggables'

"ClassListBrowser example1"
	