filterFor: aFileStream

	| rw |
	name _ aFileStream name.
	rw _ aFileStream isReadOnly not.
	aFileStream close.
	self open: name forWrite: rw.
	^self.
