setDisplayType
	"Set the display type."

	| aMenu choice on |
	aMenu _ CustomMenu new title: 'display type (currently ', displayType, ')'.
	aMenu addList:	#(
		('signal'	'signal')
		('spectrum'	'spectrum')
		('sonogram'	'sonogram')).
	choice _ aMenu startUp.
	choice ifNil: [^ self].

	on _ soundInput isRecording.
	self stop.
	displayType _ choice.
	self resetDisplay.
	on ifTrue: [self start].

