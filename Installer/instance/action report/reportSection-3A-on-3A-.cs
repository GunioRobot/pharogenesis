reportSection: line on: report
	
	report isEmpty ifFalse: [ report cr ].
	
	report nextPutAll: '">>>> ' ; nextPutAll: (line copyWithout: $"); nextPut: $"; cr.

	