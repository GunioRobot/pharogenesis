definition
	| link linkText defText |
	^definition ifNil:
		[defText _ Text fromString: 'There is no class definition for '.
		link _ TextLink new.
		linkText _ link analyze: self name with: 'Definition'.
		linkText _ Text string: (linkText ifNil: ['']) attribute: link.
		defText append: linkText; append: ' in this file'].