browseClassFromIt
	"Launch a hierarchy browser for the class indicated by the current selection.  If multiple classes matching the selection exist, let the user choose among them."

	| aClass |
	self lineSelectAndEmptyCheck: [^ self].

	aClass _ Utilities classFromPattern: (self selection string copyWithout: Character cr) withCaption: 'choose a class to browse...'.
	aClass ifNil: [^ view flash].

	self terminateAndInitializeAround:
		[self systemNavigation spawnHierarchyForClass: aClass selector: nil]