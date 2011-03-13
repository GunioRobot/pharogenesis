markersEnd
	
	"return the third marker or the second if there are only two"
	
	| str  a |
		 	 
	 str := self markers readStream.
	 a := str upToAll: '...'; upToAll: '...'.
	 str atEnd  ifTrue: [ ^a ] ifFalse: [ ^str upToEnd ]
	