subjectFilterOn: aSwitch
	"Show only those messages whose subject matches the currently selected message. The user is given a chance to edit the pattern string used to match 'Subject:' fields."

	subjectFilter _
		(currentMsgID isNil)
			ifTrue: ['']
			ifFalse: [(mailDB getTOCentry: currentMsgID) subject].
	subjectFilter _ subjectFilter withBlanksTrimmed.
	(subjectFilter asLowercase beginsWith: 're:') ifTrue: [
		subjectFilter _ subjectFilter copyFrom: 4 to: subjectFilter size.
		subjectFilter _ subjectFilter withBlanksTrimmed ].
	subjectFilter _ FillInTheBlank
		request: '''Subject:'' filter pattern?'
		initialAnswer: subjectFilter.
	subjectFilter = '' ifTrue: [aSwitch turnOff. ^self].   "User cancelled so turn off the switch and return"
	subjectFilter _ subjectFilter withoutTrailingBlanks.
	self updateTOC.