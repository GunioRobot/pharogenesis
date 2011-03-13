checkImageIsUptodate
	| stream last number |
	stream := FileDirectory default oldFileNamed: 'updates.list'.
	stream contents linesDo: [ :each | last := each ].
	stream close.
	number := (last copyUpTo: $-) asNumber.
	^ number = self getLatestUpdateNumber 