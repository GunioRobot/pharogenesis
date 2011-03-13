reconstructChanges	
	"Move all the changes and its histories onto another sources file."
	"Smalltalk reconstructChanges"

	| f oldChanges classCount |
	f := FileStream fileNamed: 'ST80.temp'.
	f header; timeStamp.
'Condensing Changes File...'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: self classNames size + self traitNames size
	during:
		[:bar | classCount := 0.
		Smalltalk allClassesAndTraitsDo:
			[:classOrTrait | bar value: (classCount := classCount + 1).
			classOrTrait moveChangesWithVersionsTo: f.
			classOrTrait putClassCommentToCondensedChangesFile: f.
			classOrTrait classSide moveChangesWithVersionsTo: f]].
	SmalltalkImage current lastQuitLogPosition: f position.
	f trailer; close.
	oldChanges := SourceFiles at: 2.
	oldChanges close.
	FileDirectory default 
		deleteFileNamed: oldChanges name , '.old';
		rename: oldChanges name toBe: oldChanges name , '.old';
		rename: f name toBe: oldChanges name.
	self setMacFileInfoOn: oldChanges name.
	SourceFiles at: 2
			put: (FileStream oldFileNamed: oldChanges name)