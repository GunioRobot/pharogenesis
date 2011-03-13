cachePackageReleaseAndOfferToCopy
	"Cache package release, then offer to copy it somewhere.
	Answer the chosen file's location after copy,
	or the cache location if no directory was chosen."

	| release installer newDir newName newFile oldFile oldName |
	release := self selectedPackageOrRelease.
	release isPackageRelease ifFalse: [ self error: 'Should be a package release!'].
	installer := SMInstaller forPackageRelease: release.
	[Cursor wait showWhile: [installer cache]] on: Error do: [:ex |
		| msg |
		msg := ex messageText ifNil: [ex asString].
		self informException: ex msg: ('Error occurred during download:\', msg, '\') withCRs.
		^nil ].
	installer isCached ifFalse: [self inform: 'Download failed, see transcript for details'. ^nil].
	oldName := installer fullFileName.
	newDir := FileList2 modalFolderSelector: installer directory.
	newDir ifNil: [ ^oldName ].
	newDir = installer directory ifTrue: [ ^oldName ].
	newName := newDir fullNameFor: installer fileName.
	newFile := FileStream newFileNamed: newName.
	newFile ifNil: [ ^oldName ].
	newFile binary.
	oldFile := FileStream readOnlyFileNamed: oldName.
	oldFile ifNil: [ ^nil ].
	oldFile binary.
	[[ newDir copyFile: oldFile toFile: newFile ] ensure: [ oldFile close. newFile close ]] on: Error do: [ :ex | ^oldName ].
	^newName