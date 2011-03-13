transposeBy: aNumber
	"Add the given step to the receiver's pitch."
	pitchPoints := pitchPoints collect: [ :each | each x @ (each y + aNumber)]