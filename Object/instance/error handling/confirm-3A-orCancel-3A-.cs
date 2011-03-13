confirm: aString orCancel: cancelBlock
	"Put up a yes/no/cancel menu with caption aString.
	Answer true if the response is yes, false if no.
	If cancel is chosen, evaluate cancelBlock."

	| choice |
	[true] whileTrue:
	[choice _ (PopUpMenu labels:
'yes
no
cancel') startUpWithCaption: aString.
	choice = 1 ifTrue: [^ true].
	choice = 2 ifTrue: [^ false].
	choice = 3 ifTrue: [^ cancelBlock value]]