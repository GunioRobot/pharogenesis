volumeIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallVolumeIcon]
		ifFalse: [MenuIcons volumeIcon]