defaultAction
	"Backward compatibility"
	| response |
	response _ (PopUpMenu labels: 'Retry\Give Up' withCRs)
			startUpWithCaption: self messageText.
	^ response = 2
		ifFalse: [self retry]