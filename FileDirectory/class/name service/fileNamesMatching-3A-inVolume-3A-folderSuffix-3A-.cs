fileNamesMatching: pat inVolume: volName folderSuffix: suffix
	"FileDirectory fileNamesMatching: '*' inVolume: '' "
	^ (MacFileDirectory directoryContentsFor: volName)
		collect: [:spec | (spec at: 4) ifTrue: [spec first , suffix]
								ifFalse: [spec first]]
		thenSelect: [:fname | pat match: fname]