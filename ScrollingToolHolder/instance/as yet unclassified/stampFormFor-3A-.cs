stampFormFor: aButton

	| which |
	which _ stampButtons indexOf: aButton ifAbsent: [1].
	^ stamps atWrap: which+start-1