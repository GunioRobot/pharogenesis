dropFiles: anEvent
	"Handle a number of dropped files from the OS.
	TODO:
		- use a more general mechanism for figuring out what to do with the file (perhaps even offering a choice from a menu)
		- remember the resource location or (when in browser) even the actual file handle
	"
	| numFiles stream sketch type |
	numFiles _ anEvent contents.
	1 to: numFiles do:[:i|
		stream _ FileStream requestDropStream: i.
		type _ stream mimeTypes.
		type ifNotNil:[type _ type first]. "for now just use the first one"
		"only image files will be handled for now"
		(type notNil and:[type beginsWith: 'image/']) ifTrue:[
			stream binary.
			sketch _ SketchMorph withForm: (Form fromBinaryStream: stream).
			self addMorph: sketch centeredNear: anEvent position.
		] ifFalse:[
			"just get us a text editor"
			stream edit.
		].
	].