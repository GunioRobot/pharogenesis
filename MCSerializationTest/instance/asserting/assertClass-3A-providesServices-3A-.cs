assertClass: readerClass providesServices: labels
	| services suffix |
	suffix := readerClass extension.
	self assert: (FileList isReaderNamedRegistered: readerClass name).
	services := readerClass fileReaderServicesForFile: 'foo' suffix: suffix.
	self assert: ((services collect: [:service | service buttonLabel]) includesAllOf: labels)