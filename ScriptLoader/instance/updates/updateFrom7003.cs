updateFrom7003
	"self new updateFrom7003"
	"
	fasterMorpic: optimized extension/properties code for number of sends
	-------
	Change Set:		AutoDeselectToolFixes-wiz
	Author:			(wiz) Jerome Peace
	For doubleClick to work in lists autoDeselect must be explicitly disabled. There are four places 	where This needs to be done on the tool end of thing.	
	-------
	0003108: [quickFix] In 7002 selecting connector catagory or alpha p catagory gets a
	 debug box.
	-------
	0002500: In6713 Sometimes a Legitimate request generates DNU PseudoClass>>isTraits
	0002991: [Fix] Workspaces initial extent is too large for most uses.
	0002151: Max number of literals checked in MethodNode instead of CompiledMethod
	0003128: [Fix] In 7002 Using browser buttons to ask for prettyprinting gets DNU 	Compiler>>asText
	0001048: [ENH] SystemNavigation>>allImplementorsOf:localTo:
	0002779: 3.9a-6721 theme... button on Services Browser gives 'key not found' walkback
	
	------
	
	"
	self script42.
	self flushCaches.
	
