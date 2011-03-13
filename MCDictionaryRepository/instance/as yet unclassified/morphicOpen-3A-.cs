morphicOpen: aWorkingCopy
	| names index infos |
	infos := self sortedVersionInfos.
	infos isEmpty ifTrue: [^ self inform: 'No versions'].
	names := infos collect: [:ea | ea name].
	index := (PopUpMenu labelArray: names) startUpWithCaption: 'Open version:'.
	index = 0 ifFalse: [(self versionWithInfo: (infos at: index)) open]