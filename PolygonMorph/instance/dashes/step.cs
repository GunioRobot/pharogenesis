step

	borderDashSpec ifNil: [^ super step].
	borderDashSpec size < 5 ifTrue: [^ super step].

	"Only for dashed lines with creep"
	borderDashSpec at: 4 put: (borderDashSpec at: 4) + (borderDashSpec at: 5).
	self changed.
	^ super step