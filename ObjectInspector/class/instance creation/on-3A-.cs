on: anObject
	^ (self basicNew setLabel: anObject defaultLabelForInspector;
					setObject: anObject) initialize