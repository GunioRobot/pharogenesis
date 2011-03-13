example2
	"
	KlattFrame example2
	"
	| frame |
	frame := self default
		voicing: 62;
		anv: 0; a1v: 62; a2v: 62; a3v: 62; a4v: 62;
		yourself.
	(KlattSynthesizer new cascade: 6; millisecondsPerFrame: 1000; soundFromFrames: {frame}) play