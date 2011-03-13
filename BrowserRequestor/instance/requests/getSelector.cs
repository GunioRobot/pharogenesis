getSelector
	| s |
	s := self getBrowser selectedMessageName.
	^ s ifNil: [super getSelector] ifNotNil: [s]