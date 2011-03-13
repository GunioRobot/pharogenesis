label: aString receiver: anObject selector: aSelector arguments: anArray keystroke: aChar
	^ (self receiver: anObject selector: aSelector arguments: anArray) 
		label: aString;
		keystroke: aChar