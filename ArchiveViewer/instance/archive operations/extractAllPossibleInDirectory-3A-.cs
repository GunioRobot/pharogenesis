extractAllPossibleInDirectory: directory
	"Answer true if I can extract all the files in the given directory safely.
	Inform the user as to problems."
	| conflicts |
	self canExtractAll ifFalse: [ ^false ].
	conflicts _ Set new.
	self members do: [ :ea | | fullName |
		fullName _ directory fullNameFor: ea localFileName.
		(ea usesFileNamed: fullName) ifTrue: [ conflicts add: fullName ].
	].
	conflicts notEmpty ifTrue: [ | str |
		str _ WriteStream on: (String new: 200).
		str nextPutAll: 'The following file(s) are needed by archive members and cannot be overwritten:';
			cr.
		conflicts do: [ :ea | str nextPutAll: ea ] separatedBy: [ str cr ].
		self inform: str contents.
		^false.
	].
	conflicts _ Set new.
	self members do: [ :ea | | fullName  |
		fullName _ directory relativeNameFor: ea localFileName.
		(directory fileExists: fullName)
			ifTrue: [ conflicts add: fullName ].
	].
	conflicts notEmpty ifTrue: [ | str |
		str _ WriteStream on: (String new: 200).
		str nextPutAll: 'The following file(s) will be overwritten:'; cr.
		conflicts do: [ :ea | str nextPutAll: ea ] separatedBy: [ str cr ].
		str cr; nextPutAll: 'Is this OK?'.
		^PopUpMenu confirm: str contents.
	].
	^true.
