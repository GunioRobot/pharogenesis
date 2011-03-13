label: aString receiver: anObject selector: aSelector arguments: anArray keystroke: aChar icon: anIcon
	^ (self receiver: anObject selector: aSelector arguments: anArray) 
		label: aString;
		keystroke: aChar;
		icon: anIcon