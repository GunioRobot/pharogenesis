openOn: aWorld label: labelString
	"Open a view with the given label on the given world."

	| windowExtent topView topLeft |
	windowExtent _ aWorld extent + (2@2).  "add border width"
	topView _ self fullColorWhenInactive
		ifTrue: [topView _ ColorSystemView new]
		ifFalse: [topView _ StandardSystemView new].
	topView model: CautiousModel new;
		borderWidth: 1;
	"	minimumSize: windowExtent;"
		addSubView: (self new initialize model: aWorld).
	aWorld setStandardTexture.
	topView backgroundColor: aWorld color dominantColor.
	topView controller openNoTerminate.
	topLeft _ ((Display extent - windowExtent) // 2) max: (0@0).
	topView resizeTo: (topLeft extent: windowExtent).
	labelString isEmpty
		ifTrue: [topView noLabel]
		ifFalse: [topView label: labelString].
	Processor terminateActive.
