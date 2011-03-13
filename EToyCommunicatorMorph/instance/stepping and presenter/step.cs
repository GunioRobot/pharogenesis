step

	| state |

	[resultQueue isEmpty] whileFalse: [
		self handleResult: resultQueue next
	].
	(state _ self valueOfProperty: #flashingState ifAbsent: [0]) > 0 ifTrue: [
		self borderColor: (
			(self valueOfProperty: #flashingColors ifAbsent: [{Color green. Color red}]) atWrap: state
		).
		self setProperty: #flashingState toValue: state + 1
	].