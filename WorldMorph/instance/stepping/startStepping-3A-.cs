startStepping: aMorph
	"Add the given morph to the step list. Do nothing if it is already being stepped."

	stepList do: [:entry | entry first = aMorph ifTrue: [^ self]].  "already stepping"
	self adjustWakeupTimesIfNecessary.
	stepList add:
		(Array with: aMorph with: Time millisecondClockValue).
