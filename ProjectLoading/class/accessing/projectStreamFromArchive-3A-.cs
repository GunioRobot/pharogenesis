projectStreamFromArchive: archive
	| ext prFiles entry unzipped |
	ext _ FileDirectory dot, Project projectExtension.
	prFiles _ archive members select:[:any| any fileName endsWith: ext].
	prFiles isEmpty ifTrue:[^''].
	entry _ prFiles first.
	unzipped _ RWBinaryOrTextStream on: (ByteArray new: entry uncompressedSize).
	entry extractTo: unzipped.
	^unzipped reset