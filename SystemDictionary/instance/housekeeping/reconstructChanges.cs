reconstructChanges	
	"Move all the changes and its histories onto another sources file."
	"Smalltalk reconstructChanges"

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
			class moveChangesWithVersionsTo: f.
			class putClassCommentToCondensedChangesFile: f.
			class class moveChangesWithVersionsTo: f]].
	SmalltalkImage current lastQuitLogPosition: f position.
	f trailer; close.
	oldChanges _ SourceFiles at: 2.
	oldChanges close.
	FileDirectory default 
		deleteFileNamed: oldChanges name , '.old';
		rename: oldChanges name toBe: oldChanges name , '.old';
		rename: f name toBe: oldChanges name.
	self setMacFileInfoOn: oldChanges name.
	SourceFiles at: 2
			put: (FileStream oldFileNamed: oldChanges name)