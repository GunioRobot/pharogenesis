printSubclassesOn: aStream level: level 
	"As part of the algorithm for printing a description of the receiver, print the
	subclass on the file stream, aStream, indenting level times."

	| subclassNames subclass |
	aStream crtab: level.
	aStream nextPutAll: self name.
	aStream space; print: self instVarNames.
	self == Class
		ifTrue: 
			[aStream crtab: level + 1; nextPutAll: '[ ... all the Metaclasses ... ]'.
			^self].
	subclassNames _ self subclasses collect: [:subC | subC name].
	"Print subclasses in alphabetical order"
	subclassNames asSortedCollection do:
		[:name |
		subclass _ self subclasses detect: [:subC | subC name = name].
		subclass printSubclassesOn: aStream level: level + 1]