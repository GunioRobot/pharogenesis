isInstalled
	| class selector |
	class := self methodClass ifNil: [^false].
	selector := self selector ifNil: [^false].
	^self == (class methodDict at: selector ifAbsent: [^false]).