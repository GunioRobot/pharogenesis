veryDeepInner: deepCopier 
	"The inner loop, so it can be overridden when a field should not  
	be traced."
	"super veryDeepInner: deepCopier.	know Object has no inst vars"
	bounds _ bounds clone.
	"Points are shared with original"
	"owner _ owner.	special, see veryDeepFixupWith:"
	submorphs _ submorphs veryDeepCopyWith: deepCopier.
	"each submorph's fixup will install me as the owner"
	"fullBounds _ fullBounds.	fullBounds is shared with original!"
	color _ color veryDeepCopyWith: deepCopier.
	"color, if simple, will return self. may be complex"
	self
		privateExtension: (self extension veryDeepCopyWith: deepCopier)