rebuild

	| row filler fudge people maxPerRow insetY |

	updateCounter _ self class updateCounter.
	self removeAllMorphs.
	(self addARow: {
		filler _ Morph new color: Color transparent; extent: 4@4.
	}) vResizing: #shrinkWrap.
	self addARow: {
		(StringMorph contents: 'the Fridge') lock.
		self groupToggleButton.
	}.
	row _ self addARow: {}.
	people _ self class fridgeRecipients.
	maxPerRow _ people size < 7 ifTrue: [2] ifFalse: [3].	
		"how big can this get before we need a different approach?"
	people do: [ :each |
		row submorphCount >= maxPerRow ifTrue: [row _ self addARow: {}].
		row addMorphBack: (
			groupMode ifTrue: [
				(each userPicture scaledToSize: 35@35) asMorph lock
			] ifFalse: [
				each veryDeepCopy killExistingChat
			]
		)
	].
	fullBounds _ nil.
	self fullBounds.
	"htsBefore _ submorphs collect: [ :each | each height]."

	fudge _ 20.
	insetY _ self layoutInset.
	insetY isPoint ifTrue: [insetY _ insetY y].
	filler extent: 
		4 @ (self height - filler height * 0.37 - insetY - borderWidth - fudge) truncated.

	"self fixLayout.
	htsAfter _ submorphs collect: [ :each | each height].
	{htsBefore. htsAfter} explore."

