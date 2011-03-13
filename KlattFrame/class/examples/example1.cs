example1
	"
	KlattFrame example1.
	KlattFrame example2.
	KlattFrame example3
	"
	| frame |
	frame := self default
		voicing: 62;
		anv: 0; a1v: 0; a2v: 0; a3v: 0; a4v: 0;
		yourself.
	(KlattSynthesizer new cascade: 6; millisecondsPerFrame: 1000; soundFromFrames: {frame}) play