condenseSources	
	"Move all the changes onto a compacted sources file."
	"Smalltalk condenseSources"

	| f dir newVersionString count |
	Utilities fixUpProblemsWithAllCategory.
	"The above removes any concrete, spurious '-- all --' categories, which mess up the process."
	dir := FileDirectory default.
	newVersionString := UIManager default request: 'Please designate the version
for the new source code file...' initialAnswer: SmalltalkImage current sourceFileVersionString.
	newVersionString ifNil: [^ self].
	newVersionString = SmalltalkImage current sourceFileVersionString ifTrue:
		[^ self error: 'The new source file must not be the same as the old.'].
	SmalltalkImage current sourceFileVersionString: newVersionString.

	"Write all sources with fileIndex 1"
	f := FileStream newFileNamed: SmalltalkImage current sourcesName.
	f nextChunkPut: self license storeString.
	f header; timeStamp.
'Condensing Sources File...'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: self classNames size + self traitNames size
	during:
		[:bar | count := 0.
		Smalltalk allClassesAndTraitsDo:
			[:classOrTrait | bar value: (count := count + 1).
			classOrTrait fileOutOn: f moveSource: true toFile: 1]].
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