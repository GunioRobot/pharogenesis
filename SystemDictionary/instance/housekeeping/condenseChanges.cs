condenseChanges		"Smalltalk condenseChanges"
	"Move all the changes onto a compacted sources file."
	| f oldChanges classCount |
	f _ FileStream fileNamed: 'ST80.temp'.
	f header; timeStamp.
'Condensing Changes File...'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: Smalltalk classNames size
	during:
		[:bar | classCount _ 0.
		Smalltalk allClassesDo:
			[:class | bar value: (classCount _ classCount + 1).
			class moveChangesTo: f.
			class class moveChangesTo: f]].
	LastQuitLogPosition _ f position.
	f trailer; close.
	oldChanges _ SourceFiles at: 2.
	oldChanges close.
	FileDirectory default deleteFileNamed: oldChanges name , '.old'.
	FileDirectory default rename: oldChanges name
						toBe: oldChanges name , '.old'.
	FileDirectory default rename: f name
						toBe: oldChanges name.
	FileDirectory default setMacFileNamed: oldChanges name
						type: 'STch' creator: 'FAST'.
	SourceFiles at: 2
			put: (StandardFileStream oldFileNamed: oldChanges name).