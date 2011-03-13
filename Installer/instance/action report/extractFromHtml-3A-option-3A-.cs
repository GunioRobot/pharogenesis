extractFromHtml: html option: allOrLast

	|  start stop test in |

	start := self markersBegin.
	stop :=  self markersEnd.
	test := self markersTest.
			 
	in := ReadWriteStream with: String new.
		
	[ html upToAll: start; atEnd ] 
		whileFalse: [
			| chunk |
			(allOrLast == #last) ifTrue: [ in resetToStart ]. 
			chunk := html upToAll: stop.
			self isSkipLoadingTestsSet ifTrue: [ chunk := chunk readStream upToAll: test ].
			in nextPutAll: chunk. 
		 ].

	^self removeHtmlMarkupFrom: in reset
	 
