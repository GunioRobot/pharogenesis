internalizeChangeLog    
		"Smalltalk internalizeChangeLog"
	"Bring the changes file into a memory-resident filestream, for faster access and freedom from external file system.  1/31/96 sw"

	| reply aName aFile |
	reply _ self confirm:  'CAUTION -- do not undertake this lightly!
If you have backed up your system and
are prepared to face the consequences of
the requested internalization of sources,
hit Yes.  If you have any doubts, hit No
to back out with no harm done.'.

	(reply ==  true) ifFalse:
		[^ self inform: 'Okay - abandoned'].

	aName _ self changesName.
	(aFile _ SourceFiles last) == nil ifTrue:
		[(FileDirectory default fileExists: aName)
			ifFalse: [^ self halt: 'Cannot locate ', aName, ' so cannot proceed.'].
		aFile _ FileStream readOnlyFileNamed: aName].
	SourceFiles at: 2 put: (ReadWriteStream with: aFile contentsOfEntireFile).

	self inform: 'Okay, changes file internalized'