edit: character		"(TextStyle default fontAt: 1) edit: $_"
	"Open a Bit Editor on the given character.  Note that you must do an accept
	(in the option menu of the bit editor) if you want this work.
	Accepted edits will not take effect in the font until you leave or close the bit editor.
	Also note that unaccepted edits will be lost when you leave or close."
	| charForm editRect scaleFactor bitEditor savedForm r |
	charForm _ self characterFormAt: character.
	editRect _ BitEditor locateMagnifiedView: charForm
	                                        scale: (scaleFactor _ 8@8).
	bitEditor _ BitEditor bitEdit: charForm at: editRect topLeft
			scale: scaleFactor remoteView: nil.
	savedForm _ Form fromDisplay: (r _ bitEditor displayBox expandBy: (0@23 corner: 0@0)).
	bitEditor controller startUp.
	bitEditor release.
	savedForm displayOn: Display at: r topLeft.
	self characterFormAt: character put: charForm