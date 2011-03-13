condenseSources		"Smalltalk condenseSources"
	"Move all the changes onto a compacted sources file."
	| f name oldChanges classCount dir |
	dir _ FileDirectory default.

	"Write all sources with fileIndex 1"
	f _ FileStream newFileNamed: self sourcesName , '.temp'.
	f header; timeStamp.
'Condensing Sources File...'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: Smalltalk classNames size
	during:
		[:bar | classCount _ 0.
		Smalltalk allClassesDo:
			[:class | bar value: (classCount _ classCount + 1).
			class fileOutOn: f moveSource: true toFile: 1]].
	f trailer; close.

	"Make a new empty changes file"
	self closeSourceFiles.
	dir rename: self changesName
		toBe: self changesName , '.old'.
	(FileStream newFileNamed: self changesName)
		header; timeStamp; close.
	LastQuitLogPosition _ 0.

	dir rename: self sourcesName
		toBe: self sourcesName , '.old'.
	dir rename: self sourcesName , '.temp'
		toBe: self sourcesName.
	self openSourceFiles.
	PopUpMenu notify: 'Source files have been rewritten!
Check that all is well,
and then save/quit.'