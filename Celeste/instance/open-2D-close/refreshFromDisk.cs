refreshFromDisk
	"look at the files on disk, and reread them if they are newer"
	mailDB ifNil: [ ^self ].

	mailDB dbStatus == #doesNotExist ifTrue: [
		"the database was on a different system"
		self close.
		^self ].

	Cursor wait showWhile: [ mailDB reopenDB ].
	self updateTOC.