heading: degrees

	| deg |
	deg _ degrees isNumber ifTrue: [degrees asFloat] ifFalse: [degrees].
	self primSetHeading: (arrays at: 4) from: deg.
