confirm: queryString 
	"Put up a yes/no menu with caption queryString. Answer true if the response is yes, false if no. This is a modal question--the user must respond yes or no."
	"SelectionMenu confirm: 'Are you hungry?'"

	| menu choice |
	menu _ self selections: #('yes' 'no').
	[true] whileTrue: [
		choice _ menu startUpWithCaption: queryString.
		choice = 'yes' ifTrue: [^ true].
		choice = 'no' ifTrue: [^ false]]