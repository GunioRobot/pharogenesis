pitchBy: aNumber
	"Multiply the receiver's pitch contour by aNumber."
	self hasPitch ifFalse: [^ self].
	pitchPoints _ pitchPoints collect: [ :each | each x @ (each y * aNumber)]