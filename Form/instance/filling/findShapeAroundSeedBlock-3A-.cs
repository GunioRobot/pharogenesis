findShapeAroundSeedBlock: seedBlock
	"Build a shape that is black in any region marked by seedBlock. 
	SeedBlock will be supplied a form, in which to blacken various
	pixels as 'seeds'.  Then the seeds are smeared until 
	there is no change in the smear when it fills the region, ie,
	when smearing hits a black border and thus goes no further."
	| smearForm previousSmear all count smearPort |
	self depth > 1 ifTrue: [self halt]. "Only meaningful for B/W forms."
	all _ self boundingBox.
	smearForm _ Form extent: self extent.
	smearPort _ BitBlt current toForm: smearForm.
	seedBlock value: smearForm.		"Blacken seeds to be smeared"
	smearPort copyForm: self to: 0@0 rule: Form erase.  "Clear any in black"
	previousSmear _ smearForm deepCopy.
	count _ 1.
	[count = 10 and:   "check for no change every 10 smears"
		[count _ 1.
		previousSmear copy: all from: 0@0 in: smearForm rule: Form reverse.
		previousSmear isAllWhite]]
		whileFalse: 
			[smearPort copyForm: smearForm to: 1@0 rule: Form under.
			smearPort copyForm: smearForm to: -1@0 rule: Form under.
			"After horiz smear, trim around the region border"
			smearPort copyForm: self to: 0@0 rule: Form erase.
			smearPort copyForm: smearForm to: 0@1 rule: Form under.
			smearPort copyForm: smearForm to: 0@-1 rule: Form under.
			"After vert smear, trim around the region border"
			smearPort copyForm: self to: 0@0 rule: Form erase.
			count _ count+1.
			count = 9 ifTrue: "Save penultimate smear for comparison"
				[previousSmear copy: all from: 0@0 in: smearForm rule: Form over]].
	"Now paint the filled region in me with aHalftone"
	^ smearForm