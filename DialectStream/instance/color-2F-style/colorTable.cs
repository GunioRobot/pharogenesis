colorTable
	"Answer the table to use to determine colors"

	^ colorTable ifNil:
		[colorTable _ dialect == #SQ00
			ifTrue:
				[Sq00ColorTable]
			ifFalse:
				[ST80ColorTable]]