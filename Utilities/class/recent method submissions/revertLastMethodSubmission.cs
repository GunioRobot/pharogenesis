revertLastMethodSubmission
	| changeRecords |
	"If the most recent method submission was a method change, revert
	that change, and if it was a submission of a brand-new method, 
	remove that method."

	RecentSubmissions isEmptyOrNil ifTrue: [^ self beep].
	Utilities setClassAndSelectorFrom: RecentSubmissions last in:
		[:aClass :aSelector |
			aClass ifNil: [^ self beep].
			changeRecords _ aClass changeRecordsAt: aSelector.
			changeRecords isEmptyOrNil ifTrue: [^ self beep].
			changeRecords size == 1
				ifTrue:
					["method has no prior version, so reverting in this case means removing"
					aClass removeSelector: aSelector]
				ifFalse:
					[changeRecords second fileIn]]

"Utilities revertLastMethodSubmission"