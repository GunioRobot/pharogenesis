veryDeepInner: deepCopier
	"The inner loop, so it can be overridden when a field should not be traced."

	"super veryDeepInner: deepCopier.	know Object has no inst vars"
	bounds _ bounds clone.	"Points are shared with original"
	"owner _ owner.	special, see veryDeepFixupWith:"
	submorphs _ submorphs veryDeepCopyWith: deepCopier.
	self submorphsDo: [:mySub | mySub privateOwner: self].		"I am the owner!"
		"My owner field:  If owner is in tree being copied, he will set it.  
		If not, if I am top object, caller will addMorph: me to another morph.
			if I am not in the submorph tree, I should not be copied.  The field I
			am in needs to be weakly copied."
	"fullBounds _ fullBounds.	fullBounds is shared with original!"
	color _ color veryDeepCopyWith: deepCopier.
		"color, if simple, will return self. may be complex"
	extension _ extension veryDeepCopyWith: deepCopier.
		"extension is treated like any generic inst var"
