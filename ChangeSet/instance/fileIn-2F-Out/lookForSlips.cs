lookForSlips
	| slips nameLine msg |
	nameLine _ '
"', self name, '"
'.
	(slips _ self checkForSlips) size == 0 ifTrue:
		[^ self inform: 'No slips detected in change set', nameLine].

	msg _ slips size == 1
		ifTrue:
			[ 'One method in change set', nameLine, 
'has a halt, reference to the Transcript,
and/or some other ''slip'' in it.
Would you like to browse it? ?']
		ifFalse:
			[ slips size printString,
' methods in change set', nameLine, 'have halts or references to the
Transcript or other ''slips'' in them.
Would you like to browse them?'].

	(self confirm: msg)
		ifTrue: [Smalltalk browseMessageList: slips
							name: 'Possible slips in ', name]