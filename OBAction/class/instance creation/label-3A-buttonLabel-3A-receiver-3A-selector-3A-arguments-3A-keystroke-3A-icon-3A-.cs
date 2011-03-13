label: aString buttonLabel: aString2 receiver: anObject selector: aSelector 
arguments: anArray keystroke: aChar icon: anIcon
	^ (self receiver: anObject selector: aSelector arguments: anArray) 
		label: aString;
		buttonLabel: aString2;
		keystroke: aChar;
		icon: anIcon