version
	| configuration |
	configuration := MCConfiguration fromArray: (MCScanner scan: stream).
	configuration name: self configurationName.
	^configuration