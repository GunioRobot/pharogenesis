okToChange

  ^hasUnsavedChanges contents not
	ifFalse:
	  [PopUpMenu confirm:
		'This drawing was not saved.\Is it OK to close this window?' withCRs
	  ]
	ifTrue:
	  [true]
