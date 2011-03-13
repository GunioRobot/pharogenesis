extractAllPossibleInDirectory: directory
	"Answer true if I can extract all the files in the given directory safely.
	Inform the user as to problems."
	| conflicts |
	self canExtractAll ifFalse: [ ^false ].
	conflicts := Set new.
	self members do: [ :ea | | fullName |
		fullName := directory fullNameFor: ea localFileName.
		(ea usesFileNamed: fullName) ifTrue: [ conflicts add: fullName ].
	].
	conflicts notEmpty ifTrue: [ | str |
		str := WriteStream on: (String new: 200).
		str nextPutAll: 'The following file(s) are needed by archive members and cannot be overwritten:';
			cr.
		conflicts do: [ :ea | str nextPutAll: ea ] separatedBy: [ str cr ].
		self inform: str contents.
		^false.
	].
	conflicts := Set new.
	self members do: [ :ea | | fullName  |
		fullName := directory relativeNameFor: ea localFileName.
		(directory fileExists: fullName)
			ifTrue: [ conflicts add: fullName ].
	].
	conflicts notEmpty ifTrue: [ | str |
		str := WriteStream on: (String new: 200).
		str nextPutAll: 'The following file(s) will be overwritten:'; cr.
		conflicts do: [ :ea | str nextPutAll: ea ] separatedBy: [ str cr ].
		str cr; nextPutAll: 'Is this OK?'.
		^self confirm: str contents.
	].
	^true.
