print: aNumber type: type on: aStream 
	"I moved the code from #printWins:on: and #printLosses:on: here because 
	it is basically 
	the same. I hope this increases the maintainability. - th 12/20/1999 20:37"
	aStream print: aNumber.
	type = #wins
		ifTrue: [aNumber = 1
				ifTrue: [aStream nextPutAll: ' win' translated]
				ifFalse: [aStream nextPutAll: ' wins' translated]].
	type = #losses
		ifTrue: [aNumber = 1
				ifTrue: [aStream nextPutAll: ' loss' translated]
				ifFalse: [aStream nextPutAll: ' losses' translated]]