cachePackageReleaseAndOfferToCopy
	"Cache package release, then offer to copy it somewhere.
	Answer the chosen file's location after copy,
	or the cache location if no directory was chosen."

	| release installer newDir newName newFile oldFile oldName |
	release _ self selectedPackageOrRelease.
	release isPackageRelease ifFalse: [ self error: 'Should be a package release!'].
	installer _ SMInstaller forPackageRelease: release.
	[Cursor wait showWhile: [ installer cache]] on: Error do: [:ex |
		| msg | 
		msg := ex messageText ifNil: [ex asString].
		self informException: ex msg: ('Error occurred during download:\', msg, '\') withCRs.
		^nil ].
	oldName _ installer fullFileName.
	newDir _ FileList2 modalFolderSelector: installer directory.
	newDir ifNil: [ ^oldName ].
	newDir = installer directory ifTrue: [ ^oldName ].
	newName _ newDir fullNameFor: installer fileName.
	newFile _ FileStream newFileNamed: newName.
	newFile ifNil: [ ^oldName ].
	oldFile _ FileStream readOnlyFileNamed: oldName.
	oldFile ifNil: [ ^nil ].
	[[ newDir copyFile: oldFile toFile: newFile ] ensure: [ oldFile close. newFile close ]] on: Error do: [ :ex | ^oldName ].
	^newName