write
	"Decide whether to write this page on the disk."
	| sf remoteFile |
	policy == #neverWrite ifTrue: [^ self].
		"demo mode, or write only when user explicitly orders it"

	"All other policies do write:   #now"
	contentsMorph ifNil: [^ self].
	dirty _ dirty | ((contentsMorph valueOfProperty: #pageDirty) == true).
		"set by layoutChanged"
	dirty == true ifTrue: [ 
		sf _ ServerDirectory new fullPath: url.
		"check for shared password"
		"contentsMorph allMorphsDo: [:m | m prepareToBeSaved].
				done in objectToStoreOnDataStream"
		lastChangeAuthor _ Utilities authorInitialsPerSe ifNil: ['*'].
		lastChangeTime _ Time totalSeconds.
		Cursor wait showWhile: [
			remoteFile _ sf fileNamed: url.	"no notification when overwriting"
			remoteFile fileOutClass: nil andObject: self.
			"remoteFile close"].
		contentsMorph setProperty: #pageDirty toValue: nil.
		dirty _ false].