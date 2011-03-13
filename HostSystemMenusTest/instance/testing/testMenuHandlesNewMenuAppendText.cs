testMenuHandlesNewMenuAppendText
	| testString |
	testString := 'testxyz'.
	self testMenuHandlesNewMenuAppend.
	interface appendMenuItemText: secondaryMenu data: testString.


	

