updatePanesFromSubmorphs
	"Having removed some submorphs, make sure this is reflected in my paneMorphs."
	paneMorphs _ paneMorphs select: [ :pane | submorphs includes: pane ].