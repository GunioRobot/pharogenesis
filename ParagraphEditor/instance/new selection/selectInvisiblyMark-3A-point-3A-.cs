selectInvisiblyMark: mark point: point
	"Select the designated characters, inclusive.  Make no visual changes."

	^ self computeIntervalFrom: mark to: point