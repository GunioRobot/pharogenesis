subjectFilterOn
	"Show only those messages whose subject matches the currently selected  
	message. The user is given a chance to edit the pattern string used to match  
	'Subject:' fields."
	subjectFilter _ currentMsgID isNil
				ifTrue: ['']
				ifFalse: [(mailDB getTOCentry: currentMsgID) subject].
	subjectFilter _ subjectFilter normalizedSubject.
	subjectFilter _ FillInTheBlank request: '''Subject:'' filter pattern?' initialAnswer: subjectFilter.
	self updateTOC.
	self changed: #isSubjectFilterOn