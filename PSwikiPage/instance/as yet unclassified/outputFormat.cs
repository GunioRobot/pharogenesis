outputFormat
	| formatCollection textBlock |
"Ah, yes, my first experience with class vars. I need to think about this
scheme a bit, but it's only	 a placeholder anyway. BJP"

	formatCollection _ OrderedCollection newFrom: super outputFormat.
	textBlock _ formatCollection last.
	^ formatCollection
		add: [:thePage | 'authName: ', thePage username
printString, '; ']
before: textBlock;
		add: [:thePage | 'authPW: ', thePage password printString,
'; ']
before: textBlock;
		add: [:thePage | 'privs: ', thePage privs printString, '; ']
before: textBlock.