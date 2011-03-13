hasDropShadowString
 	^self hasDropShadow 
		ifTrue:['<on>show shadow'] 
		ifFalse:['<off>show shadow']