getCurrentValue

	parseNode ifNil: [^nil].
	^parseNode currentValueIn: self hostContext