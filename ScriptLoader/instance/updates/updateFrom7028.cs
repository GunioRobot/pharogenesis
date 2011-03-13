updateFrom7028

	"self new updateFrom7028"
	"
	in 7028 we pushed in the update stream 
	0003426: init: method should be renamed initialize: for consistency
	------------------------------------------------------------------------------
	0003527: infinite loop on locale change (Mantis 0003510 ) not fixed yet in 7027
	------------------------------------------------------------------------------
	0003505: Context menus in ImageBrowser (OmniBrowser) crash due to missing methods in MenuIcons
	------------------------------------------------------------------------------
	0003519: Duration isZero gets MNU in 7026;fix failed
	
	"
	self script62.
	self flushCaches.
	MCDefinition clearInstances.
	Flaps initializeFlapsQuads.
     FileList registerInFlapsRegistry.  "if needed "
     TestRunner registerInToolsFlap.    "if needed "
	