step
	| time |
	super step.
	time _ String streamContents:
		[:aStrm | Time now print24: (show24hr == true) showSeconds: (showSeconds == true) on: aStrm].

	self contents: time			