addSystemStatusLinesTo: aPlayfield
	"Add three lines of system status info beneath the other items on aPlayfield"
	| aString |
	aString _ UpdatingStringMorph new target: Smalltalk.
	aString useStringFormat; color: Color blue; stepTime: 3000; getSelector: #version.
	aString setBalloonText: 'Indicates the official Squeak release code of the current image.'.
	aPlayfield addCenteredAtBottom: aString offset: 8.
	aString left: (aPlayfield left + 6).

	aString _ aString fullCopy getSelector: #lastUpdateString.
	aString setBalloonText: 'Indicates the update number of the last official update present in the image.'.
	aPlayfield addCenteredAtBottom: aString offset: 6.
	aString left: (aPlayfield left + 6).

	aString _ aString fullCopy getSelector: #currentChangeSetString.
	aString setBalloonText: 'Indicates the name of the current change set.'.
	aPlayfield addCenteredAtBottom: aString offset: 6.
	aString left: (aPlayfield left + 6)