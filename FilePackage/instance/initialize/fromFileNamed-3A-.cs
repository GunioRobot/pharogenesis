fromFileNamed: aName
	| stream |
	fullName := aName.
	packageName := FileDirectory localNameFor: fullName.
	stream := FileStream readOnlyFileNamed: aName.
	doIts := OrderedCollection new.
	classOrder := OrderedCollection new.
	sourceSystem := ''.
	self fileInFrom: stream.