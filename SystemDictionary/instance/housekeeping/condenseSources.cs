condenseSources	
	"Move all the changes onto a compacted sources file."
	"Smalltalk condenseSources"

	| f classCount dir newVersionString |
	Utilities fixUpProblemsWithAllCategory.
	"The above removes any concrete, spurious '-- all --' categories, which mess up the process."
	dir _ FileDirectory default.
	newVersionString _ FillInTheBlank request: 'Please designate the version
for the new source code file...' initialAnswer: SourceFileVersionString.
	newVersionString ifNil: [^ self].
	newVersionString = SourceFileVersionString ifTrue:
		[^ self error: 'The new source file must not be the same as the old.'].
	SourceFileVersionString _ newVersionString.

	"Write all sources with fileIndex 1"
	f _ FileStream newFileNamed: SmalltalkImage current sourcesName.
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
	SmalltalkImage current closeSourceFiles.
	dir rename: SmalltalkImage current changesName
		toBe: SmalltalkImage current changesName , '.old'.
	(FileStream newFileNamed: SmalltalkImage current changesName)
		header; timeStamp; close.
	SmalltalkImage current lastQuitLogPosition: 0.

	self setMacFileInfoOn: SmalltalkImage current changesName.
	self setMacFileInfoOn: SmalltalkImage current sourcesName.
	SmalltalkImage current openSourceFiles.
	self inform: 'Source files have been rewritten!
Check that all is well,
and then save/quit.'