exampleWithPictures
	"DataStream exampleWithPictures"
	| file result |
	file _ FileStream fileNamed: 'Test-Picture'.
	file binary.
	(DataStream on: file) nextPut: (Form fromUser).
	file close.

	file _ FileStream fileNamed: 'Test-Picture'.
	file binary.
	result _ (DataStream on: file) next.
	file close.
	result display.
	^ result