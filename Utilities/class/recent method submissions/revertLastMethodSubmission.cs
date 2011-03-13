revertLastMethodSubmission
	| changeRecords lastSubmission theClass theSelector |
	"If the most recent method submission was a method change, revert
	that change, and if it was a submission of a brand-new method, 
	remove that method."

	RecentSubmissions isEmptyOrNil ifTrue: [^ Beeper beep].
	lastSubmission := RecentSubmissions last.
	theClass := lastSubmission actualClass ifNil: [^ Beeper beep].
	theSelector := lastSubmission methodSymbol.
	changeRecords := theClass changeRecordsAt: theSelector.
	changeRecords isEmptyOrNil ifTrue: [^ Beeper beep].
	changeRecords size == 1
		ifTrue:
			["method has no prior version, so reverting in this case means removing"
			theClass removeSelector: theSelector]
		ifFalse:
			[changeRecords second fileIn].

"Utilities revertLastMethodSubmission"