fullFileListMenu: aMenu shifted: aBoolean
	"Fill the menu with all possible items for the file list pane, regardless of selection."

	| lastProvider |
	aMenu title: 'all possible file operations'.
	Smalltalk isMorphic ifTrue: [aMenu addStayUpItemSpecial].

	lastProvider _ nil.
	(self itemsForFile: 'a.*') do: [ :svc |
		(lastProvider notNil and: [svc provider ~~ lastProvider])
			ifTrue: [ aMenu addLine ].
		svc addServiceFor: self toMenu: aMenu.
		Smalltalk isMorphic ifTrue: [aMenu submorphs last setBalloonText: svc description].
		lastProvider _ svc provider.
		svc addDependent: self.
	].

	^aMenu