storeManifestFileIn: aFileDirectory

	| file |
	file _ aFileDirectory forceNewFileNamed: (self name, FileDirectory dot,'manifest').
	file ifNil: [^ self].
	file converter: UTF8TextConverter new.
	self storeAttributesOn: file.
	file close.
