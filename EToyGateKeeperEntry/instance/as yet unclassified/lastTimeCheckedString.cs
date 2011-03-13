lastTimeCheckedString

	| statusTime |
	statusTime _ self valueOfProperty: #lastTimeChecked ifAbsent: [^'none'].
	^(self dateAndTimeStringFrom: statusTime)