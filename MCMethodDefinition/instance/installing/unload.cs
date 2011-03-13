unload
	| previousVersion |
	self isOverrideMethod ifTrue: [previousVersion := self scanForPreviousVersion].
	previousVersion
		ifNil: [self actualClass ifNotNil: [:class | class removeSelector: selector]]
		ifNotNil: [previousVersion fileIn] 