setDisplayType
	"Set the display type."

	| aMenu choice on |
	aMenu _ CustomMenu new title: ('display type (currently {1})' translated format:{displayType}).
	aMenu addList:	{
		{'signal' translated.	'signal'}.
		{'spectrum' translated.	'spectrum'}.
		{'sonogram' translated.	'sonogram'}}.
	choice _ aMenu startUp.
	choice ifNil: [^ self].

	on _ soundInput isRecording.
	self stop.
	displayType _ choice.
	self resetDisplay.
	on ifTrue: [self start].

