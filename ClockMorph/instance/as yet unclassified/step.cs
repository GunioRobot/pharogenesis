step
	| time |
	super step.
	time _ String streamContents:
		[:aStrm | Time now print24: false showSeconds: (showSeconds == true) on: aStrm].

	self contents: time			