condenseChanges
	"Move all the changes onto a compacted sources file."
	"Smalltalk condenseChanges"
	| f oldChanges classCount |
	f := FileStream fileNamed: 'ST80.temp'.
	f header; timeStamp.
	'Condensing Changes File...'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: self classNames size
		during: [:bar | 
			classCount := 0.
			self
				allClassesDo: [:class | 
					bar value: (classCount := classCount + 1).
					class moveChangesTo: f.
					class putClassCommentToCondensedChangesFile: f.
					class class moveChangesTo: f]].
	SmalltalkImage current lastQuitLogPosition: f position.
	f trailer; close.
	oldChanges := SourceFiles at: 2.
	oldChanges close.
	FileDirectory default deleteFileNamed: oldChanges name , '.old';
		 rename: oldChanges name toBe: oldChanges name , '.old';
		 rename: f name toBe: oldChanges name.
	self setMacFileInfoOn: oldChanges name.
	SourceFiles
		at: 2
		put: (StandardFileStream oldFileNamed: oldChanges name)