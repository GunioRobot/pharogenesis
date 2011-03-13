confirm: aString 
	"Put up a yes/no menu with caption aString.
	Answer true if the response is yes, false if no."
	| choice |
	[true] whileTrue:
	[choice _ ConfirmMenu startUpWithCaption: aString.
	choice = 1 ifTrue: [^ true].
	choice = 2 ifTrue: [^ false]]