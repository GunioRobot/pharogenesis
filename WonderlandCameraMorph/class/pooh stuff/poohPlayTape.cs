poohPlayTape
	"| tape source | 
	tape _ FileStream fileNamed: 'pooh.tape'.
	source _ 'poohTape	^''', tape contentsOfEntireFile, ''''.
	(WonderlandCameraMorph class methodsFor: 'pooh stuff') scanFrom: (ReadStream on: source)"
	"WonderlandCameraMorph poohPlayTape"
	| stream player |
	stream _ ReadStream on: self poohTape.
	player _ EventRecorderMorph readFrom: stream.
	player openInWorld.
	Wonderland new.
	player play.
	player delete.