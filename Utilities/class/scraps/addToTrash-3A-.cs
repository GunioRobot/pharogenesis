addToTrash: aMorph
	"Paste the object onto a page of the system Trash book, unless the preference is set to empty the trash immediately."

	| aBook aPage |
	Preferences preserveTrash ifFalse: [^ self].

	aBook _ self scrapsBook.
	aMorph position: aBook pages first position + (0@40).
	aBook pages do: [:pp | 
		(pp submorphs size = 1 and: [pp hasProperty: #trash]) ifTrue:  "perhaps remove that property here"
			["page is blank"
			^ pp addMorph: aMorph]].
	aPage _ aBook insertPageLabel: Time dateAndTimeNow printString
		morphs: (Array with: aMorph).
	aPage setProperty: #trash toValue: true