fullFileListMenu: aMenu shifted: aBoolean 
	"Fill the menu with all possible items for the file list pane, regardless of
	selection. "
	| lastProvider |
	aMenu title: 'all possible file operations' translated.
	aMenu addStayUpItemSpecial.
	lastProvider := nil.
	(self itemsForFile: 'a.*')
		do: [:svc | 
			(lastProvider notNil
					and: [svc provider ~~ lastProvider])
				ifTrue: [aMenu addLine].
			svc addServiceFor: self toMenu: aMenu.
			aMenu submorphs last setBalloonText: svc description.
			lastProvider := svc provider.
			svc addDependent: self].
	^ aMenu