unload
	| previousVersion |
	self isOverrideMethod ifTrue: [previousVersion := self scanForPreviousVersion].
	previousVersion
		ifNil: [self actualClass ifNotNilDo: [:class | class removeSelector: selector]]
		ifNotNil: [previousVersion fileIn] 