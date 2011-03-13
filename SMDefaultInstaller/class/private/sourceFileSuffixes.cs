sourceFileSuffixes
	"Trying to play nice with all Squeak versions."

	^(FileStream respondsTo: #sourceFileSuffixes)
			ifTrue: [FileStream sourceFileSuffixes]
			ifFalse: [#(cs st)].