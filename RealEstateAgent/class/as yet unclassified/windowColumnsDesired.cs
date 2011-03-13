windowColumnsDesired
	"Answer how many separate vertical columns of windows are wanted.  5/22/96 sw"
	^ Preferences reverseWindowStagger
		ifTrue:
			[1]
		ifFalse:
			[(Display usableArea width > 640)
				ifTrue:
					[2]
				ifFalse:
					[1]]