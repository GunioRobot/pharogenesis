initializeFromFileNamed: aString 
	"initialize the receiver from a file named aString"
	| file result |
fileName := aString.
	elements := OrderedCollection new.
	""
	file := CrLfFileStream readOnlyFileNamed: aString.
	[result := self readFrom: file]
		ensure: [file close].
	^ result