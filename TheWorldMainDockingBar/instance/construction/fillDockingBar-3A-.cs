fillDockingBar: aDockingBar 
	"Private - fill the given docking bar"
	
	self fillMenuItemsBar: aDockingBar.
	aDockingBar addSpacer.
	Preferences tinyDisplay
		ifFalse: [

	aDockingBar
		addMorphBack: (self
				createButtonIcon: self volumeIcon
				help: 'Change sound volume' translated
				selector: #changeSoundVolume)].
	aDockingBar
		addMorphBack: (self
				createButtonIcon: self fullScreenIcon
				help: (Display isFullScreen
						ifTrue: ['Exit from full screen']
						ifFalse: ['Switch to full screen'])
				selector: #toggleFullScreen).
	aDockingBar
		addMorphBack: (self
				createButtonIcon: (SelectedObjectThumbnail
						extent: 37 @ 28
								- (Preferences tinyDisplay
										ifTrue: [12]
										ifFalse: [0])
						noSelectedThumbnail: self objectsIcon
						noSelectedBalloonText: 'View objects hierarchy' translated)
				selector: #viewSelectedObject).
	""
	aDockingBar setProperty: #mainDockingBarTimeStamp toValue: self class timeStamp