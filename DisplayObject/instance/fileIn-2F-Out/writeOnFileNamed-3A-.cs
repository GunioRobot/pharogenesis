writeOnFileNamed: fileName 
	"Saves the receiver on the file fileName in the format:
		fileCode, depth, extent, offset, bits."
	| file |
	file _ FileStream newFileNamed: fileName.
	file binary.
	file nextPut: 2.  "file code = 2"
	self writeOn: file.
	file close
"
 | f |
[(f _ Form fromUser) boundingBox area>25] whileTrue:
	[f writeOnFileNamed: 'test.form'.
	(Form newFromFileNamed: 'test.form') display].
"