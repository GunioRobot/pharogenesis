fromFileNamed: filePath action: aSwikiAction
	"Fill in all parts of this page from the info in its file"

	| theFile |
	map _ aSwikiAction urlmap.
	file _ filePath.
	theFile _ FileStream oldFileNamed: file.
	coreID _ theFile localName.
	url _ aSwikiAction name, '.', coreID.
	username _ ''. password _ ''. privs _ ''.
	self scanFrom: theFile.	"name, date"
	(username size > 1) ifTrue: ["Set up the authorization"
		aSwikiAction auth mapName: username password: password
			to: coreID.].
	address _ ''.		"should be page that points at it, but how get that?"