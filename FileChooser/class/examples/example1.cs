example1
	"Open file chooser with the standard dialog box UI."
	"FileChooser example1"
	| fc stream |
	fc := FileChooser new.
	fc initalizeAsDialogBox.
	stream := fc open.
	stream inspect.