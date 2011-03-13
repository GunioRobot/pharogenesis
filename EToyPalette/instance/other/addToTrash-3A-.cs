addToTrash: aMorph
	"Paste the object on a page.  Add new page?  Keep only N of them."

	| aPage |
	aMorph position: userStuffPalette pages first position + (0@40).
	userStuffPalette pages do: [:pp | 
		(pp submorphs size = 1 and: [pp hasProperty: #trash]) ifTrue:
			["page is blank"
			^ pp addMorph: aMorph]].
	aPage _ userStuffPalette insertPageLabel: 'From Trash Can:'
		morphs: (Array with: aMorph).
	aPage setProperty: #trash toValue: true
