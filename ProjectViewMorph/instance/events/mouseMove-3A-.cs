mouseMove: evt
	| menu selection |
	(self containsPoint: evt cursorPoint)
		ifTrue:
			[self showBorderAs: Color red.
			mouseDownTime
				ifNil:
					[mouseDownTime _ Time millisecondClockValue]
				ifNotNil:
					[((Time millisecondClockValue - mouseDownTime) > 1100)
						ifTrue:
							[menu _ CustomMenu new.
							menu add: 'enter this project' action: #enter.
							menu add: 'save (also saves a local copy)' action: #storeOnServer.
							menu add: 'saveAs' action: #store.
							menu add: 'see if server version is more recent' 
									action: #loadFromServer.
							selection _ (menu build preSelect: #enter) startUpCenteredWithCaption: ('Project Named
', 								'"', project name, '"').
							selection = #enter ifTrue: [^ self enter].
							selection = #storeOnServer ifTrue: [^ project storeOnServer].
							selection = #store ifTrue: [project urlList: nil.
										^ project storeOnServer].
							selection = #loadFromServer ifTrue: [^ project loadFromServer].
							]]]
		ifFalse:
			[self showBorderAs: Color blue.
			mouseDownTime _ nil]
