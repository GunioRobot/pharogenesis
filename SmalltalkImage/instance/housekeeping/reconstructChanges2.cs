reconstructChanges2
	"Move all the changes and its histories onto another sources file."
	"SmalltalkImage reconstructChanges2"

	| f oldChanges classCount |
	f := FileStream fileNamed: 'ST80.temp'.
	f header; timeStamp.
	(SourceFiles at: 2) converter: MacRomanTextConverter new.
'Recoding Changes File...'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: Smalltalk classNames size
	during:
		[:bar | classCount := 0.
		Smalltalk allClassesDo:
			[:class | bar value: (classCount := classCount + 1).
			class moveChangesWithVersionsTo: f.
			class putClassCommentToCondensedChangesFile: f.
			class class moveChangesWithVersionsTo: f]].
	self lastQuitLogPosition: f position.
	f trailer; close.
	oldChanges := SourceFiles at: 2.
	oldChanges close.
	FileDirectory default 
		deleteFileNamed: oldChanges name , '.old';
		rename: oldChanges name toBe: oldChanges name , '.old';
		rename: f name toBe: oldChanges name.
	Smalltalk setMacFileInfoOn: oldChanges name.
	SourceFiles at: 2
			put: (FileStream oldFileNamed: oldChanges name)