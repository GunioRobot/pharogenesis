inform: aString
	"Display a message for the user to read and then dismiss.  6/9/96 sw"

	aString size > 0 ifTrue: [(PopUpMenu labels: 'OK') startUpWithCaption: aString]