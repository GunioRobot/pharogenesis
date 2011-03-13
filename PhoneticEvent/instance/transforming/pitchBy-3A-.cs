pitchBy: aNumber
	"Multiply the receiver's pitch contour by aNumber."
	self hasPitch ifFalse: [^ self].
	pitchPoints := pitchPoints collect: [ :each | each x @ (each y * aNumber)]