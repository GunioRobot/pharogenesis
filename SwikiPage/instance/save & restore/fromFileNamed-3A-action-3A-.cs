fromFileNamed: filePath action: aSwikiAction
	"Fill in all parts of this page from the info in its file"

	| theFile |
	map _ aSwikiAction urlmap.
	file _ filePath.
	theFile _ FileStream oldFileNamed: file.
	coreID _ theFile localName.
	url _ aSwikiAction name, '.', coreID.
	self scanFrom: theFile.	"name, date"
