newFrom: aFileStream

	| rw n |
	n _ aFileStream name.
	rw _ aFileStream isReadOnly not.
	aFileStream close.
	^self new open: n forWrite: rw.
