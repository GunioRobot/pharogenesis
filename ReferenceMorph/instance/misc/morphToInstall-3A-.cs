morphToInstall: aMorph
	"Create a new tab consisting of a string holding the morph's name"
	| aLabel nameToUse |
	aLabel _ StringMorph new contents: (nameToUse _ aMorph externalName).
	self addMorph: aLabel.
	aLabel lock.
	self referent: aMorph.
	self setNameTo: nameToUse.
	self fitContents.