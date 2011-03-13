normal: degrees

	| deg |
	deg _ degrees isNumber ifTrue: [degrees asFloat] ifFalse: [degrees].
	self primSetHeading: (arrays at: 7) from: deg.
