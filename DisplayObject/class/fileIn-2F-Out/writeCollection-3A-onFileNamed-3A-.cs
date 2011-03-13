writeCollection: coll onFileNamed: fileName 
	"Saves a collection of Forms on the file fileName in the format:
		fileCode, {depth, extent, offset, bits}."
	| file |
	file _ FileStream newFileNamed: fileName.
	file binary.
	file nextPut: 2.  "file code = 2"
	coll do: [:f | f writeOn: file].
	file close
"
 | f c | c _ OrderedCollection new.
[(f _ Form fromUser) boundingBox area>25] whileTrue: [c add: f].
Form writeCollection: c onFileNamed: 'test.forms'.
c _ Form collectionFromFileNamed: 'test.forms'.
1 to: c size do: [:i | (c at: i) displayAt: 0@(i*100)].
"