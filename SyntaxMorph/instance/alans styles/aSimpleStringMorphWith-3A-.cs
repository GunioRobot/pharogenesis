aSimpleStringMorphWith: aString

	self alansTest1 ifTrue: [
		^StringMorph contents: aString font: self alansCurrentFontPreference
	].

	^StringMorph contents: aString